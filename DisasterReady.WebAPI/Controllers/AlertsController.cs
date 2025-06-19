using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alerts = await _alertService.GetAllAlertsAsync();
            return Ok(alerts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alert = await _alertService.GetAlertByIdAsync(id);
            if (alert == null) return NotFound();
            return Ok(alert);
        }

        [HttpGet("by-disaster-type/{disasterTypeId}")]
        public async Task<IActionResult> GetByDisasterType(int disasterTypeId)
        {
            var alerts = await _alertService.GetAlertsByDisasterTypeAsync(disasterTypeId);
            return Ok(alerts);
        }

        [HttpGet("by-severity/{severity}")]
        public async Task<IActionResult> GetBySeverity(SeverityLevelEnum severity)
        {
            var alerts = await _alertService.GetAlertsBySeverityAsync(severity);
            return Ok(alerts);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var alerts = await _alertService.GetActiveAlertsAsync();
            return Ok(alerts);
        }

        [HttpGet("by-region/{region}")]
        public async Task<IActionResult> GetByRegion(RegionEnum region)
        {
            var alerts = await _alertService.GetAlertsByRegionAsync(region);
            return Ok(alerts);
        }

        [HttpGet("recent/{count}")]
        public async Task<IActionResult> GetRecent(int count = 10)
        {
            var alerts = await _alertService.GetRecentAlertsAsync(count);
            return Ok(alerts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Alert alert)
        {
            var created = await _alertService.CreateAlertAsync(alert);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Alert alert)
        {
            if (id != alert.Id) return BadRequest();
            var updated = await _alertService.UpdateAlertAsync(alert);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _alertService.DeleteAlertAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 