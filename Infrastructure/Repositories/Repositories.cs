using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Infrastructure.Repositories;

public class FolderRepository : IFolderRepository
{
    private readonly AppDbContext _context;
    public FolderRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Folder>> GetAllAsync() => 
        await _context.Folders.Include(f => f.SharedUsers).ToListAsync();

    public async Task<Folder?> GetByIdAsync(int id) =>
        await _context.Folders.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(Folder folder)
    {
        _context.Folders.Add(folder);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Folder folder)
    {
        _context.Entry(folder).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Folder folder)
    {
        _context.Folders.Remove(folder);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id) => await _context.Folders.AnyAsync(e => e.Id == id);
}

public class NavigationRepository : INavigationRepository
{
    private readonly AppDbContext _context;
    public NavigationRepository(AppDbContext context) => _context = context;
    public async Task<IEnumerable<NavigationItem>> GetAllAsync() => 
        await _context.Navigations.OrderBy(n => n.Order).ToListAsync();
}

public class RecentFileRepository : IRecentFileRepository
{
    private readonly AppDbContext _context;
    public RecentFileRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<RecentFile>> GetAllAsync() => 
        await _context.RecentFiles.Include(f => f.SharedUsers).ToListAsync();

    public async Task<RecentFile?> GetByIdAsync(int id) =>
        await _context.RecentFiles.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);

    public async Task AddAsync(RecentFile file)
    {
        _context.RecentFiles.Add(file);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RecentFile file)
    {
        _context.Entry(file).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(RecentFile file)
    {
        _context.RecentFiles.Remove(file);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id) => await _context.RecentFiles.AnyAsync(e => e.Id == id);
}

public class StorageRepository : IStorageRepository
{
    private readonly AppDbContext _context;
    public StorageRepository(AppDbContext context) => _context = context;
    public async Task<StorageInfo?> GetAsync() => await _context.Storage.FirstOrDefaultAsync();
    public async Task UpdateAsync(StorageInfo storage) => await _context.SaveChangesAsync();
}

public class UserProfileRepository : IUserProfileRepository
{
    private readonly AppDbContext _context;
    public UserProfileRepository(AppDbContext context) => _context = context;
    public async Task<UserProfile?> GetAsync() => await _context.UserProfiles.FirstOrDefaultAsync();
    public async Task UpdateAsync(UserProfile userProfile) => await _context.SaveChangesAsync();
}
