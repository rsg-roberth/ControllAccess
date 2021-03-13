using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class CATRepository: Repository<CAT>, ICATRepository
    {
        public CATRepository(DataContext context):base(context){}        
    }
}