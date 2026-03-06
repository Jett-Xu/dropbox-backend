using dropbox_backend.Data;
using dropbox_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoldersController : ControllerBase
{
    private readonly AppDbContext _context;

    public FoldersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Folder>>> GetFolders()
    {
        return await _context.Folders.Include(f => f.SharedUsers).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Folder>> GetFolder(int id)
    {
        var folder = await _context.Folders.Include(f => f.SharedUsers).FirstOrDefaultAsync(f => f.Id == id);
        if (folder == null) return NotFound();
        return folder;
    }

    [HttpPost]
    public async Task<ActionResult<Folder>> CreateFolder(Folder folder)
    {
        _context.Folders.Add(folder);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFolder), new { id = folder.Id }, folder);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFolder(int id, Folder folder)
    {
        if (id != folder.Id) return BadRequest();
        
        _context.Entry(folder).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FolderExists(id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFolder(int id)
    {
        var folder = await _context.Folders.FindAsync(id);
        if (folder == null) return NotFound();

        _context.Folders.Remove(folder);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool FolderExists(int id) => _context.Folders.Any(e => e.Id == id);
}
