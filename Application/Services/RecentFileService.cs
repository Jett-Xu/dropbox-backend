using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
namespace dropbox_backend.Application.Services;
public class RecentFileService : IRecentFileService {
    private readonly IRecentFileRepository _repository;
    public RecentFileService(IRecentFileRepository repository) => _repository = repository;
    public async Task<IEnumerable<RecentFileDto>> GetAllRecentFilesAsync() => (await _repository.GetAllAsync()).Select(Mapper.ToDto);
    public async Task<bool> DeleteRecentFileAsync(int id) { var file = await _repository.GetByIdAsync(id); if (file == null) return false; await _repository.DeleteAsync(file); return true; }
}
