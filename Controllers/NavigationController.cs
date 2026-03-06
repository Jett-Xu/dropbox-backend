using dropbox_backend.Data;
using dropbox_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NavigationController : ControllerBase
{
    private readonly AppDbContext _context;

    public NavigationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NavigationItem>>> GetNavigation()
    {
        return await _context.Navigations.OrderBy(n => n.Order).ToListAsync();
    }
}
