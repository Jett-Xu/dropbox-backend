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

    [HttpGet("{id}")]
    public async Task<ActionResult<RecentFileDto>> GetRecentFile(int id)
    {
        var file = await _service.GetRecentFileByIdAsync(id);
        if (file == null) return NotFound();
        return Ok(file);
    }

    [HttpPost]
    public async Task<ActionResult<RecentFileDto>> CreateRecentFile(RecentFileDto fileDto)
    {
        var created = await _service.CreateRecentFileAsync(fileDto);
        return CreatedAtAction(nameof(GetRecentFile), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecentFile(int id, RecentFileDto fileDto)
    {
        if (id != fileDto.Id) return BadRequest();
        var updated = await _service.UpdateRecentFileAsync(id, fileDto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecentFile(int id)
    {
        var deleted = await _service.DeleteRecentFileAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
