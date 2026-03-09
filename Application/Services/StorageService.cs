using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
namespace dropbox_backend.Application.Services;
public class StorageService : IStorageService {
    private readonly IStorageRepository _repository;
    public StorageService(IStorageRepository repository) => _repository = repository;
    public async Task<StorageInfoDto?> GetStorageInfoAsync() { var info = await _repository.GetAsync(); return info == null ? null : Mapper.ToDto(info); }
}
