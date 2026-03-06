using dropbox_backend.Data;
using dropbox_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserProfileController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<UserProfile>> GetUser()
    {
        var user = await _context.UserProfiles.FirstOrDefaultAsync();
        if (user == null) return NotFound();
        return user;
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserProfile userProfile)
    {
        var user = await _context.UserProfiles.FirstOrDefaultAsync();
        if (user == null) return NotFound();

        user.Name = userProfile.Name;
        user.Avatar = userProfile.Avatar;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
