using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _feedbackService.GetAllFeedbackAsync();
            return Ok(feedback);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var feedback = await _feedbackService.GetFeedbackByUserIdAsync(userId);
            return Ok(feedback);
        }

        [HttpGet("by-type/{type}")]
        public async Task<IActionResult> GetByType(FeedbackTypeEnum type)
        {
            var feedback = await _feedbackService.GetFeedbackByTypeAsync(type);
            return Ok(feedback);
        }

        [HttpGet("recent/{count}")]
        public async Task<IActionResult> GetRecent(int count = 10)
        {
            var feedback = await _feedbackService.GetRecentFeedbackAsync(count);
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feedback feedback)
        {
            var created = await _feedbackService.CreateFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feedback feedback)
        {
            if (id != feedback.Id) return BadRequest();
            var updated = await _feedbackService.UpdateFeedbackAsync(feedback);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _feedbackService.DeleteFeedbackAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 