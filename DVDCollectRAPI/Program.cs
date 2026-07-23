using System.Text;
using DVDCollectRAPI.Data;
using DVDCollectRAPI.Services;
using Microsoft.EntityFrameworkCore;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DvdDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHostedService<XmlImportService>();
builder.Services.AddSingleton<TmdbSyncService>();
builder.Services.AddHostedService(sp => sp.GetRequiredService<TmdbSyncService>());

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Unhandled exception for {Method} {Path}", context.Request.Method, context.Request.Path);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync(
            System.Text.Json.JsonSerializer.Serialize(new { error = ex.Message }));
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
