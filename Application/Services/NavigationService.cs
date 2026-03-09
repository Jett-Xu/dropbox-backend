using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
namespace dropbox_backend.Application.Services;
public class NavigationService : INavigationService {
    private readonly INavigationRepository _repository;
    public NavigationService(INavigationRepository repository) => _repository = repository;
    public async Task<IEnumerable<NavigationItemDto>> GetNavigationAsync() => (await _repository.GetAllAsync()).Select(Mapper.ToDto);
}
