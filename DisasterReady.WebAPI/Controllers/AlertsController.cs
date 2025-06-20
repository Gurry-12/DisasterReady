using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using DisasterReady.Shared;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing disaster alerts.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        /// <summary>
        /// Retrieves all alerts.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetAll()
        {
            var alerts = await _alertService.GetAllAlertsAsync();
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Retrieves an alert by its unique identifier.
        /// </summary>
        /// <param name="id">The alert ID.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<Alert>>> GetById(int id)
        {
            var alert = await _alertService.GetAlertByIdAsync(id);
            if (alert == null) return NotFound(new ApiResult<Alert> { Success = false, Message = "Alert not found" });
            return Ok(new ApiResult<Alert> { Success = true, Data = alert });
        }

        /// <summary>
        /// Retrieves alerts by disaster type.
        /// </summary>
        /// <param name="disasterTypeId">The disaster type ID.</param>
        [HttpGet("by-disaster-type/{disasterTypeId}")]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetByDisasterType(int disasterTypeId)
        {
            var alerts = await _alertService.GetAlertsByDisasterTypeAsync(disasterTypeId);
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Retrieves alerts by severity level.
        /// </summary>
        /// <param name="severity">The severity level.</param>
        [HttpGet("by-severity/{severity}")]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetBySeverity(SeverityLevelEnum severity)
        {
            var alerts = await _alertService.GetAlertsBySeverityAsync(severity);
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Retrieves all active alerts.
        /// </summary>
        [HttpGet("active")]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetActive()
        {
            var alerts = await _alertService.GetActiveAlertsAsync();
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Retrieves alerts by region.
        /// </summary>
        /// <param name="region">The region.</param>
        [HttpGet("by-region/{region}")]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetByRegion(RegionEnum region)
        {
            var alerts = await _alertService.GetAlertsByRegionAsync(region);
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Retrieves the most recent alerts.
        /// </summary>
        /// <param name="count">The number of recent alerts to retrieve.</param>
        [HttpGet("recent/{count}")]
        public async Task<ActionResult<ApiResult<IEnumerable<Alert>>>> GetRecent(int count = 10)
        {
            var alerts = await _alertService.GetRecentAlertsAsync(count);
            return Ok(new ApiResult<IEnumerable<Alert>> { Success = true, Data = alerts });
        }

        /// <summary>
        /// Creates a new alert.
        /// </summary>
        /// <param name="alert">The alert to create.</param>
        [HttpPost]
        public async Task<ActionResult<ApiResult<Alert>>> Create(Alert alert)
        {
            var created = await _alertService.CreateAlertAsync(alert);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResult<Alert> { Success = true, Data = created });
        }

        /// <summary>
        /// Updates an existing alert.
        /// </summary>
        /// <param name="id">The alert ID.</param>
        /// <param name="alert">The updated alert object.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<Alert>>> Update(int id, Alert alert)
        {
            if (id != alert.Id) return BadRequest(new ApiResult<Alert> { Success = false, Message = "ID mismatch" });
            var updated = await _alertService.UpdateAlertAsync(alert);
            if (updated == null) return NotFound(new ApiResult<Alert> { Success = false, Message = "Alert not found" });
            return Ok(new ApiResult<Alert> { Success = true, Data = updated });
        }

        /// <summary>
        /// Deletes an alert by its ID.
        /// </summary>
        /// <param name="id">The alert ID.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<object>>> Delete(int id)
        {
            var deleted = await _alertService.DeleteAlertAsync(id);
            if (!deleted) return NotFound(new ApiResult<object> { Success = false, Message = "Alert not found" });
            return Ok(new ApiResult<object> { Success = true, Message = "Alert deleted successfully" });
        }
    }
} 