using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing emergency tips.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyTipsController : ControllerBase
    {
        private readonly IEmergencyTipService _emergencyTipService;

        public EmergencyTipsController(IEmergencyTipService emergencyTipService)
        {
            _emergencyTipService = emergencyTipService;
        }

        /// <summary>
        /// Retrieves all emergency tips.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tips = await _emergencyTipService.GetAllEmergencyTipsAsync();
            return Ok(tips);
        }

        /// <summary>
        /// Retrieves an emergency tip by its unique identifier.
        /// </summary>
        /// <param name="id">The emergency tip ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tip = await _emergencyTipService.GetEmergencyTipByIdAsync(id);
            if (tip == null) return NotFound();
            return Ok(tip);
        }

        /// <summary>
        /// Retrieves emergency tips by disaster type.
        /// </summary>
        /// <param name="disasterType">The disaster type.</param>
        [HttpGet("by-disaster-type/{disasterType}")]
        public async Task<IActionResult> GetByDisasterType(DisasterTypeEnum disasterType)
        {
            var tips = await _emergencyTipService.GetEmergencyTipsByDisasterTypeAsync(disasterType);
            return Ok(tips);
        }

        /// <summary>
        /// Retrieves a random set of emergency tips.
        /// </summary>
        /// <param name="count">The number of random tips to retrieve.</param>
        [HttpGet("random/{count}")]
        public async Task<IActionResult> GetRandom(int count = 5)
        {
            var tips = await _emergencyTipService.GetRandomTipsAsync(count);
            return Ok(tips);
        }

        /// <summary>
        /// Creates a new emergency tip.
        /// </summary>
        /// <param name="tip">The emergency tip to create.</param>
        [HttpPost]
        public async Task<IActionResult> Create(EmergencyTip tip)
        {
            var created = await _emergencyTipService.CreateEmergencyTipAsync(tip);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing emergency tip.
        /// </summary>
        /// <param name="id">The emergency tip ID.</param>
        /// <param name="tip">The updated emergency tip object.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmergencyTip tip)
        {
            if (id != tip.Id) return BadRequest();
            var updated = await _emergencyTipService.UpdateEmergencyTipAsync(tip);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Deletes an emergency tip by its ID.
        /// </summary>
        /// <param name="id">The emergency tip ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _emergencyTipService.DeleteEmergencyTipAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 