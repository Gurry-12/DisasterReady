using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Persistence.Data;

namespace DisasterReady.Infrastucture.ConcreteRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DisasterReadyDbContext context) : base(context) { }


    }
}