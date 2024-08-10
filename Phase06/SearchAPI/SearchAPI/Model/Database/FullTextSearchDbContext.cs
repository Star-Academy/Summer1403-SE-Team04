using Microsoft.EntityFrameworkCore;

namespace SearchAPI.Model.Database;

public class FullTextSearchDbContext : DbContext
{
    public DbSet<InvertedIndexDataStore> InvertedIndexDataStores { get; set; }
    public DbSet<DocDataStore> DocDataStores { get; set; }

    public FullTextSearchDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvertedIndexDataStore>().HasKey(i => i.DirectoryPath);
        modelBuilder.Entity<DocDataStore>().HasKey(d => d.Name);
    }
}