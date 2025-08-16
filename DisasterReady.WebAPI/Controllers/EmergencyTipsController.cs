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

        
    }
} 