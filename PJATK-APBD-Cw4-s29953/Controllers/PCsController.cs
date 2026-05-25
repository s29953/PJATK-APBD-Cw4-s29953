using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw4_s29953.DTOs;
using PJATK_APBD_Cw4_s29953.Services;

namespace PJATK_APBD_Cw4_s29953.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController : ControllerBase
{
    private readonly IPCService _pcService;

    public PCsController(IPCService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pcs = await _pcService.GetAllAsync();
        return Ok(pcs);
    }

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var components = await _pcService.GetComponentsByPcIdAsync(id);

        if (components == null)
            return NotFound();

        return Ok(components);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PCRequestDto dto)
    {
        var createdPc = await _pcService.CreateAsync(dto);

        return CreatedAtAction(nameof(GetAll), new { id = createdPc.Id }, createdPc);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PCRequestDto dto)
    {
        var updated = await _pcService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _pcService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}