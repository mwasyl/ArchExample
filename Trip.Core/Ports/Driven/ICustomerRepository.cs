using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;

namespace Trip.Core.Ports.Driven
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyCollection<Customer>> Get();
        Task<Customer> Get(UserId id);
        void Save(Customer travel);
    }
}
