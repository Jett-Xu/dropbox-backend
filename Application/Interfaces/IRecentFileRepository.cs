using dropbox_backend.Domain.Entities;
namespace dropbox_backend.Application.Interfaces;
public interface IRecentFileRepository {
    Task<IEnumerable<RecentFile>> GetAllAsync();
    Task<RecentFile?> GetByIdAsync(int id);
    Task DeleteAsync(RecentFile file);
}
