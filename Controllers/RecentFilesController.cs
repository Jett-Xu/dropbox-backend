using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecentFilesController : ControllerBase
{
    private readonly IRecentFileService _service;

    public RecentFilesController(IRecentFileService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecentFileDto>>> GetRecentFiles()
    {
        var files = await _service.GetAllRecentFilesAsync();
        return Ok(files);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecentFile(int id)
    {
        var deleted = await _service.DeleteRecentFileAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
