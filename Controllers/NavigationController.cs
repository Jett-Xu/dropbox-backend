using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NavigationController : ControllerBase
{
    private readonly INavigationService _service;

    public NavigationController(INavigationService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NavigationItemDto>>> GetNavigation()
    {
        var nav = await _service.GetNavigationAsync();
        return Ok(nav);
    }
}
