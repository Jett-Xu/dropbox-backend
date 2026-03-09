using dropbox_backend.Domain.Entities;
namespace dropbox_backend.Application.Interfaces;
public interface INavigationRepository {
    Task<IEnumerable<NavigationItem>> GetAllAsync();
}
