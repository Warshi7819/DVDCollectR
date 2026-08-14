using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Data;

public class DvdDbContext : DbContext
{
    public DvdDbContext(DbContextOptions<DvdDbContext> options) : base(options) { }

    public DbSet<DvdEntity> DVDs => Set<DvdEntity>();
    public DbSet<GenreEntity> Genres => Set<GenreEntity>();
    public DbSet<TmdbEntity> Tmdb => Set<TmdbEntity>();
    public DbSet<AppSettingEntity> AppSettings => Set<AppSettingEntity>();
    public DbSet<ThemeEntity> Themes => Set<ThemeEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DvdEntity>(entity =>
        {
            entity.HasIndex(e => e.ProfileId).IsUnique();
        });

        modelBuilder.Entity<DvdEntity>()
            .HasMany(d => d.Genres)
            .WithMany(g => g.DVDs)
            .UsingEntity(t => t.ToTable("DVDGenres"));

        modelBuilder.Entity<TmdbEntity>(entity =>
        {
            entity.HasOne(t => t.Dvd)
                .WithOne(d => d.Tmdb)
                .HasForeignKey<TmdbEntity>(t => t.DvdId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
