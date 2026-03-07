using dropbox_backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<StorageInfo> Storage { get; set; }
    public DbSet<Folder> Folders { get; set; }
    public DbSet<RecentFile> RecentFiles { get; set; }
    public DbSet<SharedUser> SharedUsers { get; set; }
    public DbSet<NavigationItem> Navigations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
