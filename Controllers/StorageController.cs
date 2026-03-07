using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dropbox_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StorageController : ControllerBase
{
    private readonly IStorageService _service;

    public StorageController(IStorageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<StorageInfoDto>> GetStorage()
    {
        var storage = await _service.GetStorageInfoAsync();
        if (storage == null) return NotFound();
        return Ok(storage);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStorage(StorageInfoDto storageInfoDto)
    {
        var updated = await _service.UpdateStorageInfoAsync(storageInfoDto);
        if (!updated) return NotFound();
        return NoContent();
    }
}
