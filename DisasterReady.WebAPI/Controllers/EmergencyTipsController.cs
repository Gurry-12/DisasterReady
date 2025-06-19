using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmergencyTipsController : ControllerBase
    {
        private readonly IEmergencyTipService _emergencyTipService;

        public EmergencyTipsController(IEmergencyTipService emergencyTipService)
        {
            _emergencyTipService = emergencyTipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tips = await _emergencyTipService.GetAllEmergencyTipsAsync();
            return Ok(tips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tip = await _emergencyTipService.GetEmergencyTipByIdAsync(id);
            if (tip == null) return NotFound();
            return Ok(tip);
        }

        [HttpGet("by-disaster-type/{disasterType}")]
        public async Task<IActionResult> GetByDisasterType(DisasterTypeEnum disasterType)
        {
            var tips = await _emergencyTipService.GetEmergencyTipsByDisasterTypeAsync(disasterType);
            return Ok(tips);
        }

        [HttpGet("random/{count}")]
        public async Task<IActionResult> GetRandom(int count = 5)
        {
            var tips = await _emergencyTipService.GetRandomTipsAsync(count);
            return Ok(tips);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmergencyTip tip)
        {
            var created = await _emergencyTipService.CreateEmergencyTipAsync(tip);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmergencyTip tip)
        {
            if (id != tip.Id) return BadRequest();
            var updated = await _emergencyTipService.UpdateEmergencyTipAsync(tip);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _emergencyTipService.DeleteEmergencyTipAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 