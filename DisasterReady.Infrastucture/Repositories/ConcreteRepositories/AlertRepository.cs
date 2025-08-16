using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Persistence.Data;

namespace DisasterReady.Infrastucture.ConcreteRepositories
{
    public class AlertRepository : Repository<Alert>, IAlertRepository
    {
        public AlertRepository(DisasterReadyDbContext context) : base(context) { }


    }
}