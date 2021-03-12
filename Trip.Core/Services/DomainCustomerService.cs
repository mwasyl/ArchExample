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

        public async Task CreateCustomer(Customer customer)
        {
            await _customerRepository.Create(customer);
        }

        public async Task EditCustomer(Guid customerId, Customer editedCustomer)
        {
            Customer customer = await _customerRepository.Get(UserId.FromGuid(customerId));
            customer.Edit(editedCustomer);
            await _customerRepository.Update(customer);
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
