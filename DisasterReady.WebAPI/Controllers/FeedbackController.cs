using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing user feedback.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        /// <summary>
        /// Retrieves all feedback entries.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _feedbackService.GetAllFeedbackAsync();
            return Ok(feedback);
        }

        /// <summary>
        /// Retrieves a feedback entry by its unique identifier.
        /// </summary>
        /// <param name="id">The feedback ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        /// <summary>
        /// Retrieves feedback entries by user ID.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var feedback = await _feedbackService.GetFeedbackByUserIdAsync(userId);
            return Ok(feedback);
        }

        /// <summary>
        /// Retrieves feedback entries by feedback type.
        /// </summary>
        /// <param name="type">The feedback type.</param>
        [HttpGet("by-type/{type}")]
        public async Task<IActionResult> GetByType(FeedbackTypeEnum type)
        {
            var feedback = await _feedbackService.GetFeedbackByTypeAsync(type);
            return Ok(feedback);
        }

        /// <summary>
        /// Retrieves the most recent feedback entries.
        /// </summary>
        /// <param name="count">The number of recent feedback entries to retrieve.</param>
        [HttpGet("recent/{count}")]
        public async Task<IActionResult> GetRecent(int count = 10)
        {
            var feedback = await _feedbackService.GetRecentFeedbackAsync(count);
            return Ok(feedback);
        }

        /// <summary>
        /// Creates a new feedback entry.
        /// </summary>
        /// <param name="feedback">The feedback entry to create.</param>
        [HttpPost]
        public async Task<IActionResult> Create(Feedback feedback)
        {
            var created = await _feedbackService.CreateFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing feedback entry.
        /// </summary>
        /// <param name="id">The feedback ID.</param>
        /// <param name="feedback">The updated feedback object.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feedback feedback)
        {
            if (id != feedback.Id) return BadRequest();
            var updated = await _feedbackService.UpdateFeedbackAsync(feedback);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a feedback entry by its ID.
        /// </summary>
        /// <param name="id">The feedback ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _feedbackService.DeleteFeedbackAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 