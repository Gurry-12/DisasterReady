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

        /// <summary>
        /// Retrieves all checklists.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<Checklist>>>> GetAll()
        {
            var checklists = await _checklistService.GetAllChecklistsAsync();
            return Ok(new ApiResult<IEnumerable<Checklist>> { Success = true, Data = checklists });
        }

        /// <summary>
        /// Retrieves a checklist by its unique identifier.
        /// </summary>
        /// <param name="id">The checklist ID.</param>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<Checklist>>> GetById(int id)
        {
            var checklist = await _checklistService.GetChecklistByIdAsync(id);
            if (checklist == null) return NotFound(new ApiResult<Checklist> { Success = false, Message = "Checklist not found" });
            return Ok(new ApiResult<Checklist> { Success = true, Data = checklist });
        }

        /// <summary>
        /// Retrieves all checklists for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<ApiResult<IEnumerable<Checklist>>>> GetByUserId(int userId)
        {
            var checklists = await _checklistService.GetChecklistsByUserIdAsync(userId);
            return Ok(new ApiResult<IEnumerable<Checklist>> { Success = true, Data = checklists });
        }

        /// <summary>
        /// Creates a new checklist.
        /// </summary>
        /// <param name="checklist">The checklist to create.</param>
        [HttpPost]
        public async Task<ActionResult<ApiResult<Checklist>>> Create(Checklist checklist)
        {
            var created = await _checklistService.CreateChecklistAsync(checklist);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, new ApiResult<Checklist> { Success = true, Data = created });
        }

        /// <summary>
        /// Updates an existing checklist.
        /// </summary>
        /// <param name="id">The checklist ID.</param>
        /// <param name="checklist">The updated checklist object.</param>
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<Checklist>>> Update(int id, Checklist checklist)
        {
            if (id != checklist.Id) return BadRequest(new ApiResult<Checklist> { Success = false, Message = "ID mismatch" });
            var updated = await _checklistService.UpdateChecklistAsync(checklist);
            if (updated == null) return NotFound(new ApiResult<Checklist> { Success = false, Message = "Checklist not found" });
            return Ok(new ApiResult<Checklist> { Success = true, Data = updated });
        }

        /// <summary>
        /// Deletes a checklist by its ID.
        /// </summary>
        /// <param name="id">The checklist ID.</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<object>>> Delete(int id)
        {
            var deleted = await _checklistService.DeleteChecklistAsync(id);
            if (!deleted) return NotFound(new ApiResult<object> { Success = false, Message = "Checklist not found" });
            return Ok(new ApiResult<object> { Success = true, Message = "Checklist deleted successfully" });
        }

        /// <summary>
        /// Retrieves all items for a specific checklist.
        /// </summary>
        /// <param name="checklistId">The checklist ID.</param>
        [HttpGet("{checklistId}/items")]
        public async Task<ActionResult<ApiResult<IEnumerable<ChecklistItem>>>> GetItems(int checklistId)
        {
            var items = await _checklistService.GetChecklistItemsAsync(checklistId);
            return Ok(new ApiResult<IEnumerable<ChecklistItem>> { Success = true, Data = items });
        }

        /// <summary>
        /// Adds a new item to a checklist.
        /// </summary>
        /// <param name="item">The checklist item to add.</param>
        [HttpPost("items")]
        public async Task<ActionResult<ApiResult<ChecklistItem>>> AddItem(ChecklistItem item)
        {
            var created = await _checklistService.AddChecklistItemAsync(item);
            return CreatedAtAction(nameof(GetItems), new { checklistId = created.ChecklistId }, new ApiResult<ChecklistItem> { Success = true, Data = created });
        }

        /// <summary>
        /// Updates an existing checklist item.
        /// </summary>
        /// <param name="itemId">The checklist item ID.</param>
        /// <param name="item">The updated checklist item object.</param>
        [HttpPut("items/{itemId}")]
        public async Task<ActionResult<ApiResult<ChecklistItem>>> UpdateItem(int itemId, ChecklistItem item)
        {
            if (itemId != item.Id) return BadRequest(new ApiResult<ChecklistItem> { Success = false, Message = "ID mismatch" });
            var updated = await _checklistService.UpdateChecklistItemAsync(item);
            if (updated == null) return NotFound(new ApiResult<ChecklistItem> { Success = false, Message = "Checklist item not found" });
            return Ok(new ApiResult<ChecklistItem> { Success = true, Data = updated });
        }

        /// <summary>
        /// Removes an item from a checklist.
        /// </summary>
        /// <param name="itemId">The checklist item ID.</param>
        [HttpDelete("items/{itemId}")]
        public async Task<ActionResult<ApiResult<object>>> RemoveItem(int itemId)
        {
            var deleted = await _checklistService.RemoveChecklistItemAsync(itemId);
            if (!deleted) return NotFound(new ApiResult<object> { Success = false, Message = "Checklist item not found" });
            return Ok(new ApiResult<object> { Success = true, Message = "Checklist item removed successfully" });
        }
    }
} 