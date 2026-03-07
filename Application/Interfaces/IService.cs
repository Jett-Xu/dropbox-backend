using dropbox_backend.Application.DTOs;

namespace dropbox_backend.Application.Interfaces;

public interface IFolderService
{
    Task<IEnumerable<FolderDto>> GetAllFoldersAsync();
    Task<FolderDto?> GetFolderByIdAsync(int id);
    Task<FolderDto> CreateFolderAsync(FolderDto folderDto);
    Task<bool> UpdateFolderAsync(int id, FolderDto folderDto);
    Task<bool> DeleteFolderAsync(int id);
}

public interface INavigationService
{
    Task<IEnumerable<NavigationItemDto>> GetNavigationAsync();
}

public interface IRecentFileService
{
    Task<IEnumerable<RecentFileDto>> GetAllRecentFilesAsync();
    Task<RecentFileDto?> GetRecentFileByIdAsync(int id);
    Task<RecentFileDto> CreateRecentFileAsync(RecentFileDto fileDto);
    Task<bool> UpdateRecentFileAsync(int id, RecentFileDto fileDto);
    Task<bool> DeleteRecentFileAsync(int id);
}

public interface IStorageService
{
    Task<StorageInfoDto?> GetStorageInfoAsync();
    Task<bool> UpdateStorageInfoAsync(StorageInfoDto storageDto);
}

public interface IUserProfileService
{
    Task<UserProfileDto?> GetUserProfileAsync();
    Task<bool> UpdateUserProfileAsync(UserProfileDto profileDto);
}
