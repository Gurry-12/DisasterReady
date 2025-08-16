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

        
    }
} 