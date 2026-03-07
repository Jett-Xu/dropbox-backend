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

    [HttpGet("{id}")]
    public async Task<ActionResult<FolderDto>> GetFolder(int id)
    {
        var folder = await _service.GetFolderByIdAsync(id);
        if (folder == null) return NotFound();
        return Ok(folder);
    }

    [HttpPost]
    public async Task<ActionResult<FolderDto>> CreateFolder(FolderDto folderDto)
    {
        var created = await _service.CreateFolderAsync(folderDto);
        return CreatedAtAction(nameof(GetFolder), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFolder(int id, FolderDto folderDto)
    {
        if (id != folderDto.Id) return BadRequest();
        var updated = await _service.UpdateFolderAsync(id, folderDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFolder(int id)
    {
        var deleted = await _service.DeleteFolderAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
