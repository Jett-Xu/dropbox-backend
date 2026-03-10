using System.Text.Json;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Infrastructure.Seed;

public class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context, string webRootPath)
    {
        // 每次應用程式啟動時，先強制刪除並重建資料庫，確保每次測試拿到的都是 `seed-data.json` 裡最乾淨的初始狀態
        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
        var seedFilePath = Path.Combine(webRootPath, "Infrastructure", "Seed", "seed-data.json");
        if (!File.Exists(seedFilePath))
            return;

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var jsonData = await File.ReadAllTextAsync(seedFilePath);
        var seedData = JsonSerializer.Deserialize<SeedDataModel>(jsonData, jsonOptions);

        if (seedData == null) return;

        if (seedData.Storage != null) await context.Storage.AddRangeAsync(seedData.Storage);
        if (seedData.UserProfiles != null) await context.UserProfiles.AddRangeAsync(seedData.UserProfiles);
        if (seedData.NavigationItems != null) await context.Navigations.AddRangeAsync(seedData.NavigationItems);
        if (seedData.Folders != null) await context.Folders.AddRangeAsync(seedData.Folders);
        if (seedData.RecentFiles != null) await context.RecentFiles.AddRangeAsync(seedData.RecentFiles);
        
        // Save first so that folders and recentfiles get their identity IDs (though they are explicit in JSON)
        // With explicit IDs in JSON and using identity columns, EF might throw if IDENTITY_INSERT is off.
        // Actually, since this is PostgreSQL or similar EF provider, if we set the ID manually, EF will issue an INSERT with the ID if the column does not auto-generate.
        // Or we might need to enable IDENTITY_INSERT. However, for a simple schema, we just Add them.
        await context.SaveChangesAsync();

        if (seedData.SharedUsers != null)
        {
            await context.SharedUsers.AddRangeAsync(seedData.SharedUsers);
            await context.SaveChangesAsync();
        }
    }

    private class SeedDataModel
    {
        public List<StorageInfo>? Storage { get; set; }
        public List<UserProfile>? UserProfiles { get; set; }
        public List<NavigationItem>? NavigationItems { get; set; }
        public List<Folder>? Folders { get; set; }
        public List<RecentFile>? RecentFiles { get; set; }
        public List<SharedUser>? SharedUsers { get; set; }
    }
}
