using Domain.Entities;
using Domain.Repositories;
using Infra.Context;

namespace Infra.Repositories
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context):base(context){}        
    }
}