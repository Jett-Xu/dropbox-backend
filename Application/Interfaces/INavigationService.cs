using dropbox_backend.Application.DTOs;
namespace dropbox_backend.Application.Interfaces;
public interface INavigationService {
    Task<IEnumerable<NavigationItemDto>> GetNavigationAsync();
}
