using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace dropbox_backend.Infrastructure.Repositories;
public class RecentFileRepository : IRecentFileRepository {
    private readonly AppDbContext _context;
    public RecentFileRepository(AppDbContext context) => _context = context;
    public async Task<IEnumerable<RecentFile>> GetAllAsync() => await _context.RecentFiles.Include(f => f.SharedUsers).ToListAsync();
    public async Task<RecentFile?> GetByIdAsync(int id) => await _context.RecentFiles.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);
    public async Task DeleteAsync(RecentFile file) { _context.RecentFiles.Remove(file); await _context.SaveChangesAsync(); }
}
