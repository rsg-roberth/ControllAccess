using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class AccessRepository: Repository<Access>, IAccessRepository
    {
        public AccessRepository(DataContext context):base(context){}        
    }
}