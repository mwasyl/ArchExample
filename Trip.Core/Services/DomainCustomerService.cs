using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Ports.Driven;

namespace Trip.Core.Services
{
    public class DomainCustomerService : IDomainCustomerService
    {
        private ICustomerRepository _customerRepository;

        public DomainCustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task CreateCustomer(Customer customer)
        {
            _customerRepository.Save(customer);
            return Task.CompletedTask;
        }

        public void EditCustomer(Guid customerId, Customer editedCustomer)
        {
            Customer customer = _customerRepository.Get(UserId.FromGuid(customerId)).GetAwaiter().GetResult();
            customer.Edit(editedCustomer);
            _customerRepository.Save(customer);
        }

        public Task<Customer> GetCustomer(UserId userId)
        {
            return _customerRepository.Get(userId);
        }

        public async Task<IReadOnlyCollection<Customer>> GetCustomers()
        {
            return await _customerRepository.Get();
        }
    }
}
