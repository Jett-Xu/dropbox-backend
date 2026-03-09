using dropbox_backend.Application.DTOs;
namespace dropbox_backend.Application.Interfaces;
public interface IUserProfileService {
    Task<UserProfileDto?> GetUserProfileAsync();
}
