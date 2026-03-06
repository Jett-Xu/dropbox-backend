using dropbox_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Data;

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

        modelBuilder.Entity<StorageInfo>().HasData(
            new StorageInfo { Id = 1, Used = 600, Total = 800, Unit = "GB", Percentage = 75 }
        );

        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile { Id = 1, Name = "James Alto", Avatar = "assets/avatars/avatar-1.png" }
        );

        modelBuilder.Entity<NavigationItem>().HasData(
            new NavigationItem { Id = "home", Label = "Home", Icon = "assets/icons/icon-home.svg", Order = 1 },
            new NavigationItem { Id = "my-files", Label = "My Files", Icon = "assets/icons/icon-my-files.svg", Order = 2 },
            new NavigationItem { Id = "starred", Label = "Starred", Icon = "assets/icons/icon-starred.svg", Order = 3 },
            new NavigationItem { Id = "shared", Label = "Shared", Icon = "assets/icons/icon-shared.svg", Order = 4 },
            new NavigationItem { Id = "file-requests", Label = "Files Requests", Icon = "assets/icons/icon-file-requests.svg", Order = 5 },
            new NavigationItem { Id = "deleted", Label = "Deleted", Icon = "assets/icons/icon-deleted.svg", Order = 6 }
        );

        modelBuilder.Entity<Folder>().HasData(
            new Folder { Id = 1, Name = "Documents", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 3985, SharedUsersCount = 86 },
            new Folder { Id = 2, Name = "Music", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 499, SharedUsersCount = 85 },
            new Folder { Id = 3, Name = "ProjectK", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 256, SharedUsersCount = 0 },
            new Folder { Id = 4, Name = "Rico Media", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 1225, SharedUsersCount = 52 },
            new Folder { Id = 5, Name = "New Dev", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 2265, SharedUsersCount = 22 },
            new Folder { Id = 6, Name = "Files 2022", ModifiedDate = "Sep 25, 2022, 13:25 PM", InsideFiles = 597, SharedUsersCount = 12 }
        );

        modelBuilder.Entity<RecentFile>().HasData(
            new RecentFile { Id = 1, Name = "Website Design.png", Size = "2.8 MB", ModifiedDate = "Dec 13, 2022", Type = "image", Icon = "assets/icons/icon-file-image.svg", SharedUsersCount = 12 },
            new RecentFile { Id = 2, Name = "UX-UI.zip", Size = "242 MB", ModifiedDate = "Dec 12, 2022", Type = "archive", Icon = "assets/icons/icon-folder.svg", SharedUsersCount = 5 },
            new RecentFile { Id = 3, Name = "Office.mp4", Size = "1.8 GB", ModifiedDate = "Dec 12, 2022", Type = "video", Icon = "assets/icons/icon-video.svg", SharedUsersCount = 0 }
        );

        modelBuilder.Entity<SharedUser>().HasData(
            // Folder 1
            new SharedUser { Id = 1, FolderId = 1, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 2, FolderId = 1, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 3, FolderId = 1, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 4, FolderId = 1, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            new SharedUser { Id = 5, FolderId = 1, Name = "User 5", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 6, FolderId = 1, Name = "User 6", Avatar = "assets/avatars/avatar-2.png" },
            // Folder 2
            new SharedUser { Id = 7, FolderId = 2, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 8, FolderId = 2, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 9, FolderId = 2, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 10, FolderId = 2, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            new SharedUser { Id = 11, FolderId = 2, Name = "User 5", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 12, FolderId = 2, Name = "User 6", Avatar = "assets/avatars/avatar-2.png" },
            // Folder 3
            new SharedUser { Id = 13, FolderId = 3, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 14, FolderId = 3, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 15, FolderId = 3, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            // Folder 4
            new SharedUser { Id = 16, FolderId = 4, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 17, FolderId = 4, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 18, FolderId = 4, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 19, FolderId = 4, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            // Folder 5
            new SharedUser { Id = 20, FolderId = 5, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 21, FolderId = 5, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 22, FolderId = 5, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 23, FolderId = 5, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            // Folder 6
            new SharedUser { Id = 24, FolderId = 6, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 25, FolderId = 6, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 26, FolderId = 6, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            // RecentFile 1
            new SharedUser { Id = 27, RecentFileId = 1, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 28, RecentFileId = 1, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 29, RecentFileId = 1, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 30, RecentFileId = 1, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            new SharedUser { Id = 31, RecentFileId = 1, Name = "User 5", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 32, RecentFileId = 1, Name = "User 6", Avatar = "assets/avatars/avatar-2.png" },
            // RecentFile 2
            new SharedUser { Id = 33, RecentFileId = 2, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 34, RecentFileId = 2, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" },
            new SharedUser { Id = 35, RecentFileId = 2, Name = "User 3", Avatar = "assets/avatars/avatar-3.png" },
            new SharedUser { Id = 36, RecentFileId = 2, Name = "User 4", Avatar = "assets/avatars/avatar-4.png" },
            new SharedUser { Id = 37, RecentFileId = 2, Name = "User 5", Avatar = "assets/avatars/avatar-1.png" },
            // RecentFile 3
            new SharedUser { Id = 38, RecentFileId = 3, Name = "User 1", Avatar = "assets/avatars/avatar-1.png" },
            new SharedUser { Id = 39, RecentFileId = 3, Name = "User 2", Avatar = "assets/avatars/avatar-2.png" }
        );
    }
}
