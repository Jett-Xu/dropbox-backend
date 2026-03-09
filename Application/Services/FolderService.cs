using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
namespace dropbox_backend.Application.Services;
public class FolderService : IFolderService {
    private readonly IFolderRepository _repository;
    public FolderService(IFolderRepository repository) => _repository = repository;
    public async Task<IEnumerable<FolderDto>> GetAllFoldersAsync() => (await _repository.GetAllAsync()).Select(Mapper.ToDto);
    public async Task<bool> DeleteFolderAsync(int id) { var folder = await _repository.GetByIdAsync(id); if (folder == null) return false; await _repository.DeleteAsync(folder); return true; }
}
