using dropbox_backend.Application.DTOs;
namespace dropbox_backend.Application.Interfaces;
public interface IRecentFileService {
    Task<IEnumerable<RecentFileDto>> GetAllRecentFilesAsync();
    Task<bool> DeleteRecentFileAsync(int id);
}
