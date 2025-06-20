using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing disaster types.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DisasterTypesController : ControllerBase
    {
        private readonly IDisasterTypeService _disasterTypeService;

        public DisasterTypesController(IDisasterTypeService disasterTypeService)
        {
            _disasterTypeService = disasterTypeService;
        }

        /// <summary>
        /// Retrieves all disaster types.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var disasterTypes = await _disasterTypeService.GetAllDisasterTypesAsync();
            return Ok(disasterTypes);
        }

        /// <summary>
        /// Retrieves a disaster type by its unique identifier.
        /// </summary>
        /// <param name="id">The disaster type ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var disasterType = await _disasterTypeService.GetDisasterTypeByIdAsync(id);
            if (disasterType == null) return NotFound();
            return Ok(disasterType);
        }

        /// <summary>
        /// Retrieves a disaster type by its name.
        /// </summary>
        /// <param name="name">The disaster type name.</param>
        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(DisasterTypeEnum name)
        {
            var disasterType = await _disasterTypeService.GetDisasterTypeByNameAsync(name);
            if (disasterType == null) return NotFound();
            return Ok(disasterType);
        }

        /// <summary>
        /// Retrieves disaster types by region.
        /// </summary>
        /// <param name="region">The region.</param>
        [HttpGet("by-region/{region}")]
        public async Task<IActionResult> GetByRegion(RegionEnum region)
        {
            var disasterTypes = await _disasterTypeService.GetDisasterTypesByRegionAsync(region);
            return Ok(disasterTypes);
        }

        /// <summary>
        /// Creates a new disaster type.
        /// </summary>
        /// <param name="disasterType">The disaster type to create.</param>
        [HttpPost]
        public async Task<IActionResult> Create(DisasterType disasterType)
        {
            var created = await _disasterTypeService.CreateDisasterTypeAsync(disasterType);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing disaster type.
        /// </summary>
        /// <param name="id">The disaster type ID.</param>
        /// <param name="disasterType">The updated disaster type object.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DisasterType disasterType)
        {
            if (id != disasterType.Id) return BadRequest();
            var updated = await _disasterTypeService.UpdateDisasterTypeAsync(disasterType);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a disaster type by its ID.
        /// </summary>
        /// <param name="id">The disaster type ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _disasterTypeService.DeleteDisasterTypeAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 