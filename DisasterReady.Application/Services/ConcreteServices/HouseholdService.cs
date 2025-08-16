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

       
    }
} 