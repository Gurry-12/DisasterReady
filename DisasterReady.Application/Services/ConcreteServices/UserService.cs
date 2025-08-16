using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Services.ConcreteServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
} 