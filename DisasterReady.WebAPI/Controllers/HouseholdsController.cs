using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DisasterReady.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HouseholdsController : ControllerBase
    {
        private readonly IHouseholdService _householdService;

        public HouseholdsController(IHouseholdService householdService)
        {
            _householdService = householdService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var households = await _householdService.GetAllHouseholdsAsync();
            return Ok(households);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var household = await _householdService.GetHouseholdByIdAsync(id);
            if (household == null) return NotFound();
            return Ok(household);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var household = await _householdService.GetHouseholdByUserIdAsync(userId);
            if (household == null) return NotFound();
            return Ok(household);
        }

        [HttpGet("with-medical-needs")]
        public async Task<IActionResult> GetWithMedicalNeeds()
        {
            var households = await _householdService.GetHouseholdsWithMedicalNeedsAsync();
            return Ok(households);
        }

        [HttpGet("with-pets")]
        public async Task<IActionResult> GetWithPets()
        {
            var households = await _householdService.GetHouseholdsWithPetsAsync();
            return Ok(households);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Household household)
        {
            var created = await _householdService.CreateHouseholdAsync(household);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Household household)
        {
            if (id != household.Id) return BadRequest();
            var updated = await _householdService.UpdateHouseholdAsync(household);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _householdService.DeleteHouseholdAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
} 