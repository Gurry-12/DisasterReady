using DisasterReady.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("disaster-types")]
        public async Task<IActionResult> GetDisasterTypes()
        {
            var disasterTypes = await _unitOfWork.DisasterTypes.GetAllAsync();
            return Ok(disasterTypes);
        }

        [HttpGet("emergency-tips")]
        public async Task<IActionResult> GetEmergencyTips()
        {
            var tips = await _unitOfWork.EmergencyTips.GetAllAsync();
            return Ok(tips);
        }

        [HttpGet("alerts")]
        public async Task<IActionResult> GetAlerts()
        {
            var alerts = await _unitOfWork.Alerts.GetAllAsync();
            return Ok(alerts);
        }
    }
} 