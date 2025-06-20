using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for test endpoints to retrieve users, disaster types, emergency tips, and alerts.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieves all users (test endpoint).
        /// </summary>
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Retrieves all disaster types (test endpoint).
        /// </summary>
        [HttpGet("disaster-types")]
        public async Task<IActionResult> GetDisasterTypes()
        {
            var disasterTypes = await _unitOfWork.DisasterTypes.GetAllAsync();
            return Ok(disasterTypes);
        }

        /// <summary>
        /// Retrieves all emergency tips (test endpoint).
        /// </summary>
        [HttpGet("emergency-tips")]
        public async Task<IActionResult> GetEmergencyTips()
        {
            var tips = await _unitOfWork.EmergencyTips.GetAllAsync();
            return Ok(tips);
        }

        /// <summary>
        /// Retrieves all alerts (test endpoint).
        /// </summary>
        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlerts()
        {
            var alerts = await _unitOfWork.Alerts.GetAllAsync();
            return Ok(alerts);
        }
    }
} 