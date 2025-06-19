using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisasterTypesController : ControllerBase
    {
        private readonly IDisasterTypeService _disasterTypeService;

        public DisasterTypesController(IDisasterTypeService disasterTypeService)
        {
            _disasterTypeService = disasterTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var disasterTypes = await _disasterTypeService.GetAllDisasterTypesAsync();
            return Ok(disasterTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var disasterType = await _disasterTypeService.GetDisasterTypeByIdAsync(id);
            if (disasterType == null) return NotFound();
            return Ok(disasterType);
        }

        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(DisasterTypeEnum name)
        {
            var disasterType = await _disasterTypeService.GetDisasterTypeByNameAsync(name);
            if (disasterType == null) return NotFound();
            return Ok(disasterType);
        }

        [HttpGet("by-region/{region}")]
        public async Task<IActionResult> GetByRegion(RegionEnum region)
        {
            var disasterTypes = await _disasterTypeService.GetDisasterTypesByRegionAsync(region);
            return Ok(disasterTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DisasterType disasterType)
        {
            var created = await _disasterTypeService.CreateDisasterTypeAsync(disasterType);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DisasterType disasterType)
        {
            if (id != disasterType.Id) return BadRequest();
            var updated = await _disasterTypeService.UpdateDisasterTypeAsync(disasterType);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _disasterTypeService.DeleteDisasterTypeAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 