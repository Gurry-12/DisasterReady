using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services.ConcreteServices
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

       
    }
} 