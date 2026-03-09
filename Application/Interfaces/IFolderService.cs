using dropbox_backend.Application.DTOs;
namespace dropbox_backend.Application.Interfaces;
public interface IFolderService {
    Task<IEnumerable<FolderDto>> GetAllFoldersAsync();
    Task<bool> DeleteFolderAsync(int id);
}
