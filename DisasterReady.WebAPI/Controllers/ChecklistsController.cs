using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using DisasterReady.Shared;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing user checklists and checklist items.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistsController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistsController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

       
    }
} 