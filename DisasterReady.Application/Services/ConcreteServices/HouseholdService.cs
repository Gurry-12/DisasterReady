using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;

namespace DisasterReady.Application.Services.ConcreteServices
{
    public class HouseholdService : IHouseholdService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HouseholdService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Household>> GetAllHouseholdsAsync()
        {
            return await _unitOfWork.Households.GetAllAsync();
        }

        public async Task<Household?> GetHouseholdByIdAsync(int id)
        {
            return await _unitOfWork.Households.GetByIdAsync(id);
        }

        public async Task<Household?> GetHouseholdByUserIdAsync(int userId)
        {
            return await _unitOfWork.Households.GetSingleAsync(h => h.UserId == userId);
        }

        public async Task<Household> CreateHouseholdAsync(Household household)
        {
            var createdHousehold = await _unitOfWork.Households.AddAsync(household);
            await _unitOfWork.SaveChangesAsync();
            return createdHousehold;
        }

        public async Task<bool> DeleteHouseholdAsync(int id)
        {
            var household = await _unitOfWork.Households.GetByIdAsync(id);
            if (household == null) return false;
            _unitOfWork.Households.Delete(household);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Household?> UpdateHouseholdAsync(Household household)
        {
            var existing = await _unitOfWork.Households.GetByIdAsync(household.Id);
            if (existing == null) return null;
            existing.Adults = household.Adults;
            existing.Children = household.Children;
            existing.HasPets = household.HasPets;
            existing.HasMedicalNeeds = household.HasMedicalNeeds;
            existing.Notes = household.Notes;
            _unitOfWork.Households.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<Household>> GetHouseholdsWithMedicalNeedsAsync()
        {
            return await _unitOfWork.Households.GetAsync(h => h.HasMedicalNeeds);
        }

        public async Task<IEnumerable<Household>> GetHouseholdsWithPetsAsync()
        {
            return await _unitOfWork.Households.GetAsync(h => h.HasPets);
        }
    }
} 