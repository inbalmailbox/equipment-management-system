using Equipment.Api.DTOs;
using Equipment.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _service;

    public EquipmentController(IEquipmentService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get all equipment items
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<EquipmentDto>> GetAll()
    {
        var items = _service.GetAll();
        return Ok(items);
    }

    /// <summary>
    /// Create new equipment item
    /// </summary>
    [HttpPost]
    public ActionResult<EquipmentDto> Create([FromBody] CreateEquipmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = _service.Create(dto);

        return CreatedAtAction(
            nameof(GetAll),
            new { id = created.Id },
            created
        );
    }

    /// <summary>
    /// Update equipment item
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<EquipmentDto> Update(int id, [FromBody] CreateEquipmentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = _service.Update(id, dto);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// Delete equipment item
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var removed = _service.Delete(id);
        if (!removed)
            return NotFound();

        return NoContent();
    }

}
