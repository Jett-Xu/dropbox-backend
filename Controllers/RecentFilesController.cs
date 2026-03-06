using dropbox_backend.Data;
using dropbox_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecentFilesController : ControllerBase
{
    private readonly AppDbContext _context;

    public RecentFilesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RecentFile>>> GetRecentFiles()
    {
        return await _context.RecentFiles.Include(f => f.SharedUsers).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecentFile>> GetRecentFile(int id)
    {
        var file = await _context.RecentFiles.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);
        if (file == null) return NotFound();
        return file;
    }

    [HttpPost]
    public async Task<ActionResult<RecentFile>> CreateRecentFile(RecentFile file)
    {
        _context.RecentFiles.Add(file);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRecentFile), new { id = file.Id }, file);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecentFile(int id, RecentFile file)
    {
        if (id != file.Id) return BadRequest();
        
        _context.Entry(file).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RecentFileExists(id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecentFile(int id)
    {
        var file = await _context.RecentFiles.FindAsync(id);
        if (file == null) return NotFound();

        _context.RecentFiles.Remove(file);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool RecentFileExists(int id) => _context.RecentFiles.Any(e => e.Id == id);
}
