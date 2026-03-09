using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;
using dropbox_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace dropbox_backend.Infrastructure.Repositories;
public class UserProfileRepository : IUserProfileRepository {
    private readonly AppDbContext _context;
    public UserProfileRepository(AppDbContext context) => _context = context;
    public async Task<UserProfile?> GetAsync() => await _context.UserProfiles.FirstOrDefaultAsync();
}
