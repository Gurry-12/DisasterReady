using DisasterReady.Application.Common;
using DisasterReady.Application.Services.AbstractServices;
using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Shared.Enums;
using System.Net;

namespace DisasterReady.Application.Services.ConcreteServices
{
    public class AlertService : IAlertService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
    }
} 