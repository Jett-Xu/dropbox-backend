using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace dropbox_backend.Infrastructure.Repositories;
public class NavigationRepository : INavigationRepository {
    private readonly AppDbContext _context;
    public NavigationRepository(AppDbContext context) => _context = context;
    public async Task<IEnumerable<NavigationItem>> GetAllAsync() => await _context.Navigations.OrderBy(n => n.Order).ToListAsync();
}
