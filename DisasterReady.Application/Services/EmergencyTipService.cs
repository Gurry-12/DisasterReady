using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Interfaces;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services
{
    public class EmergencyTipService : IEmergencyTipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Random _random;

        public EmergencyTipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _random = new Random();
        }

        public async Task<IEnumerable<EmergencyTip>> GetAllEmergencyTipsAsync()
        {
            return await _unitOfWork.EmergencyTips.GetAllAsync();
        }

        public async Task<EmergencyTip?> GetEmergencyTipByIdAsync(int id)
        {
            return await _unitOfWork.EmergencyTips.GetByIdAsync(id);
        }

        public async Task<IEnumerable<EmergencyTip>> GetEmergencyTipsByDisasterTypeAsync(DisasterTypeEnum disasterType)
        {
            return await _unitOfWork.EmergencyTips.GetAsync(tip => tip.DisasterType == disasterType);
        }

        public async Task<EmergencyTip> CreateEmergencyTipAsync(EmergencyTip tip)
        {
            var createdTip = await _unitOfWork.EmergencyTips.AddAsync(tip);
            await _unitOfWork.SaveChangesAsync();
            return createdTip;
        }

        public async Task<bool> DeleteEmergencyTipAsync(int id)
        {
            var tip = await _unitOfWork.EmergencyTips.GetByIdAsync(id);
            if (tip == null) return false;
            _unitOfWork.EmergencyTips.Delete(tip);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<EmergencyTip?> UpdateEmergencyTipAsync(EmergencyTip tip)
        {
            var existing = await _unitOfWork.EmergencyTips.GetByIdAsync(tip.Id);
            if (existing == null) return null;
            existing.TipTitle = tip.TipTitle;
            existing.Description = tip.Description;
            existing.DisasterType = tip.DisasterType;
            _unitOfWork.EmergencyTips.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<EmergencyTip>> GetRandomTipsAsync(int count = 5)
        {
            var allTips = await _unitOfWork.EmergencyTips.GetAllAsync();
            var tipsList = allTips.ToList();
            
            if (tipsList.Count <= count)
                return tipsList;

            var randomTips = new List<EmergencyTip>();
            var usedIndices = new HashSet<int>();

            while (randomTips.Count < count && usedIndices.Count < tipsList.Count)
            {
                var index = _random.Next(tipsList.Count);
                if (usedIndices.Add(index))
                {
                    randomTips.Add(tipsList[index]);
                }
            }

            return randomTips;
        }
    }
} 