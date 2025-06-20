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

        /// <summary>
        /// Retrieves all households.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var households = await _householdService.GetAllHouseholdsAsync();
            return Ok(households);
        }

        /// <summary>
        /// Retrieves a household by its unique identifier.
        /// </summary>
        /// <param name="id">The household ID.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var household = await _householdService.GetHouseholdByIdAsync(id);
            if (household == null) return NotFound();
            return Ok(household);
        }

        /// <summary>
        /// Retrieves a household by user ID.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var household = await _householdService.GetHouseholdByUserIdAsync(userId);
            if (household == null) return NotFound();
            return Ok(household);
        }

        /// <summary>
        /// Retrieves all households with medical needs.
        /// </summary>
        [HttpGet("with-medical-needs")]
        public async Task<IActionResult> GetWithMedicalNeeds()
        {
            var households = await _householdService.GetHouseholdsWithMedicalNeedsAsync();
            return Ok(households);
        }

        /// <summary>
        /// Retrieves all households with pets.
        /// </summary>
        [HttpGet("with-pets")]
        public async Task<IActionResult> GetWithPets()
        {
            var households = await _householdService.GetHouseholdsWithPetsAsync();
            return Ok(households);
        }

        /// <summary>
        /// Creates a new household.
        /// </summary>
        /// <param name="household">The household to create.</param>
        [HttpPost]
        public async Task<IActionResult> Create(Household household)
        {
            var created = await _householdService.CreateHouseholdAsync(household);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing household.
        /// </summary>
        /// <param name="id">The household ID.</param>
        /// <param name="household">The updated household object.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Household household)
        {
            if (id != household.Id) return BadRequest();
            var updated = await _householdService.UpdateHouseholdAsync(household);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a household by its ID.
        /// </summary>
        /// <param name="id">The household ID.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _householdService.DeleteHouseholdAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 