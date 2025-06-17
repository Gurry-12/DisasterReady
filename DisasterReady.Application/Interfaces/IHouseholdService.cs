using DisasterReady.Domain.Entities;

namespace DisasterReady.Application.Interfaces
{
    public interface IHouseholdService
    {
        Task<IEnumerable<Household>> GetAllHouseholdsAsync();
        Task<Household?> GetHouseholdByIdAsync(int id);
        Task<Household?> GetHouseholdByUserIdAsync(int userId);
        Task<Household> CreateHouseholdAsync(Household household);
        Task<bool> DeleteHouseholdAsync(int id);
        Task<Household?> UpdateHouseholdAsync(Household household);
        Task<IEnumerable<Household>> GetHouseholdsWithMedicalNeedsAsync();
        Task<IEnumerable<Household>> GetHouseholdsWithPetsAsync();
    }
} 