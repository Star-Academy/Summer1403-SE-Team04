using Microsoft.EntityFrameworkCore;

namespace SearchAPI.Model.Database;

public class FullTextSearchDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<InvertedIndexDataStore> InvertedIndexDataStores { get; set; }
    public DbSet<DocDataStore> DocDataStores { get; set; }

    public FullTextSearchDbContext(DbContextOptions<FullTextSearchDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<InvertedIndexDataStore>().HasKey(i => i.DirectoryPath);
        modelBuilder.Entity<DocDataStore>().HasKey(d => d.name);
    }
}