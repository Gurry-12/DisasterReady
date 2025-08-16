using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;


namespace DisasterReady.Application.Services.ConcreteServices
{
    public class ChecklistService : IChecklistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChecklistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
    }
} 