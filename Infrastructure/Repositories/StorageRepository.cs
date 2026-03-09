using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace dropbox_backend.Infrastructure.Repositories;
public class StorageRepository : IStorageRepository {
    private readonly AppDbContext _context;
    public StorageRepository(AppDbContext context) => _context = context;
    public async Task<StorageInfo?> GetAsync() => await _context.Storage.FirstOrDefaultAsync();
}
