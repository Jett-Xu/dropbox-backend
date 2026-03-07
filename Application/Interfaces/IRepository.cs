using dropbox_backend.Domain.Entities;

namespace dropbox_backend.Application.Interfaces;

public interface IFolderRepository
{
    Task<IEnumerable<Folder>> GetAllAsync();
    Task<Folder?> GetByIdAsync(int id);
    Task AddAsync(Folder folder);
    Task UpdateAsync(Folder folder);
    Task DeleteAsync(Folder folder);
    Task<bool> ExistsAsync(int id);
}

public interface INavigationRepository
{
    Task<IEnumerable<NavigationItem>> GetAllAsync();
}

public interface IRecentFileRepository
{
    Task<IEnumerable<RecentFile>> GetAllAsync();
    Task<RecentFile?> GetByIdAsync(int id);
    Task AddAsync(RecentFile file);
    Task UpdateAsync(RecentFile file);
    Task DeleteAsync(RecentFile file);
    Task<bool> ExistsAsync(int id);
}

public interface IStorageRepository
{
    Task<StorageInfo?> GetAsync();
    Task UpdateAsync(StorageInfo storage);
}

public interface IUserProfileRepository
{
    Task<UserProfile?> GetAsync();
    Task UpdateAsync(UserProfile userProfile);
}
