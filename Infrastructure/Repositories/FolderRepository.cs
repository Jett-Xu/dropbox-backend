using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace dropbox_backend.Infrastructure.Repositories;
public class FolderRepository : IFolderRepository {
    private readonly AppDbContext _context;
    public FolderRepository(AppDbContext context) => _context = context;
    public async Task<IEnumerable<Folder>> GetAllAsync() => await _context.Folders.Include(f => f.SharedUsers).ToListAsync();
    public async Task<Folder?> GetByIdAsync(int id) => await _context.Folders.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);
    public async Task DeleteAsync(Folder folder) { _context.Folders.Remove(folder); await _context.SaveChangesAsync(); }
}
