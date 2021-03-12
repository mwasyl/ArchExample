using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;

namespace Trip.Core.Services
{
    public interface IDomainCustomerService
    {
        Task<IReadOnlyCollection<Customer>> GetCustomers();
        Task<Customer> GetCustomer(UserId userId);
        Task CreateCustomer(Customer customer);
        void EditCustomer(Guid customerId, Customer editedCustomer);
    }
}
