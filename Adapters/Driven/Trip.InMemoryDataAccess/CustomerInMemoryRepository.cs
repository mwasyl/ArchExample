using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Ports.Driven;

namespace Trip.InMemoryDataAccess
{
    public class CustomerInMemoryRepository : ICustomerRepository
    {
        private List<Customer> _customers = new List<Customer>
            {
                new Customer(UserId.FromGuid(Guid.Parse("b12d9364-2753-4e40-a131-4ba7144041dd")), "John", "Smith"),
                new Customer(UserId.FromGuid(Guid.Parse("7be74db4-e6b0-4b49-8ed4-376a315c8d98")), "John2", "Smith2"),
                new Customer(UserId.FromGuid(Guid.Parse("0048202b-7f28-4e29-bb5f-f76ba8291128")), "John3", "Smith3"),
            };

        public Task<IReadOnlyCollection<Customer>> Get()
        {
            return Task.FromResult<IReadOnlyCollection<Customer>>(_customers);
        }

        public Task<Customer> Get(UserId id)
        {
            return Task.FromResult(_customers.SingleOrDefault(p => p.Id.Equals(id))); //TODO: to use custom made equals operator in value object
        }

        public void Save(Customer travel)
        {
            throw new NotImplementedException();
        }
    }
}
