using dropbox_backend.Data;
using dropbox_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : ControllerBase
{
    private readonly AppDbContext _context;

    public StorageController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<StorageInfo>> GetStorage()
    {
        var storage = await _context.Storage.FirstOrDefaultAsync();
        if (storage == null) return NotFound();
        return storage;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStorage(StorageInfo storageInfo)
    {
        var storage = await _context.Storage.FirstOrDefaultAsync();
        if (storage == null) return NotFound();

        storage.Used = storageInfo.Used;
        storage.Total = storageInfo.Total;
        storage.Unit = storageInfo.Unit;
        storage.Percentage = storageInfo.Percentage;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
