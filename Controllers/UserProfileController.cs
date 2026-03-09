using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _service;

    public UserProfileController(IUserProfileService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<UserProfileDto>> GetUser()
    {
        var user = await _service.GetUserProfileAsync();
        if (user == null) return NotFound();
        return Ok(user);
    }
}
