using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistsController : ControllerBase
    {
        private readonly IChecklistService _checklistService;

        public ChecklistsController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var checklists = await _checklistService.GetAllChecklistsAsync();
            return Ok(checklists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var checklist = await _checklistService.GetChecklistByIdAsync(id);
            if (checklist == null) return NotFound();
            return Ok(checklist);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var checklists = await _checklistService.GetChecklistsByUserIdAsync(userId);
            return Ok(checklists);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Checklist checklist)
        {
            var created = await _checklistService.CreateChecklistAsync(checklist);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Checklist checklist)
        {
            if (id != checklist.Id) return BadRequest();
            var updated = await _checklistService.UpdateChecklistAsync(checklist);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _checklistService.DeleteChecklistAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpGet("{checklistId}/items")]
        public async Task<IActionResult> GetItems(int checklistId)
        {
            var items = await _checklistService.GetChecklistItemsAsync(checklistId);
            return Ok(items);
        }

        [HttpPost("items")]
        public async Task<IActionResult> AddItem(ChecklistItem item)
        {
            var created = await _checklistService.AddChecklistItemAsync(item);
            return CreatedAtAction(nameof(GetItems), new { checklistId = created.ChecklistId }, created);
        }

        [HttpPut("items/{itemId}")]
        public async Task<IActionResult> UpdateItem(int itemId, ChecklistItem item)
        {
            if (itemId != item.Id) return BadRequest();
            var updated = await _checklistService.UpdateChecklistItemAsync(item);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("items/{itemId}")]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            var deleted = await _checklistService.RemoveChecklistItemAsync(itemId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 