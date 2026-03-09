using dropbox_backend.Domain.Entities;
namespace dropbox_backend.Application.Interfaces;
public interface IFolderRepository {
    Task<IEnumerable<Folder>> GetAllAsync();
    Task<Folder?> GetByIdAsync(int id);
    Task DeleteAsync(Folder folder);
}
