using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing households and household-related queries.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HouseholdsController : ControllerBase
    {
        private readonly IHouseholdService _householdService;

        public HouseholdsController(IHouseholdService householdService)
        {
            _householdService = householdService;
        }

        
    }
} 