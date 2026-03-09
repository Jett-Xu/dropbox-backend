using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoldersController : ControllerBase
{
    private readonly IFolderService _service;

    public FoldersController(IFolderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FolderDto>>> GetFolders()
    {
        var folders = await _service.GetAllFoldersAsync();
        return Ok(folders);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFolder(int id)
    {
        var deleted = await _service.DeleteFolderAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
