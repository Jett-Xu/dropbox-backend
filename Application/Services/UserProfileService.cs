using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
namespace dropbox_backend.Application.Services;
public class UserProfileService : IUserProfileService {
    private readonly IUserProfileRepository _repository;
    public UserProfileService(IUserProfileRepository repository) => _repository = repository;
    public async Task<UserProfileDto?> GetUserProfileAsync() { var info = await _repository.GetAsync(); return info == null ? null : Mapper.ToDto(info); }
}
