using Microsoft.EntityFrameworkCore;

namespace DVDCollectRAPI.Data;

public class DvdDbContext : DbContext
{
    public DvdDbContext(DbContextOptions<DvdDbContext> options) : base(options) { }

    public DbSet<DvdEntity> DVDs => Set<DvdEntity>();
    public DbSet<GenreEntity> Genres => Set<GenreEntity>();

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
    }
}
