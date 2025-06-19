using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services.ConcreteServices
{
    public class DisasterTypeService : IDisasterTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisasterTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DisasterType>> GetAllDisasterTypesAsync()
        {
            return await _unitOfWork.DisasterTypes.GetAllAsync();
        }

        public async Task<DisasterType?> GetDisasterTypeByIdAsync(int id)
        {
            return await _unitOfWork.DisasterTypes.GetByIdAsync(id);
        }

        public async Task<DisasterType?> GetDisasterTypeByNameAsync(DisasterTypeEnum name)
        {
            return await _unitOfWork.DisasterTypes.GetSingleAsync(dt => dt.Name == name);
        }

        public async Task<IEnumerable<DisasterType>> GetDisasterTypesByRegionAsync(RegionEnum region)
        {
            return await _unitOfWork.DisasterTypes.GetAsync(dt => dt.Region == region);
        }

        public async Task<DisasterType> CreateDisasterTypeAsync(DisasterType disasterType)
        {
            var createdDisasterType = await _unitOfWork.DisasterTypes.AddAsync(disasterType);
            await _unitOfWork.SaveChangesAsync();
            return createdDisasterType;
        }

        public async Task<bool> DeleteDisasterTypeAsync(int id)
        {
            var disasterType = await _unitOfWork.DisasterTypes.GetByIdAsync(id);
            if (disasterType == null) return false;
            _unitOfWork.DisasterTypes.Delete(disasterType);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<DisasterType?> UpdateDisasterTypeAsync(DisasterType disasterType)
        {
            var existing = await _unitOfWork.DisasterTypes.GetByIdAsync(disasterType.Id);
            if (existing == null) return null;
            existing.Name = disasterType.Name;
            existing.Description = disasterType.Description;
            existing.Region = disasterType.Region;
            _unitOfWork.DisasterTypes.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }
    }
} 