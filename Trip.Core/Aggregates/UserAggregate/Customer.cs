using Trip.Core.Dtos;

namespace Trip.Core.Aggregates.UserAggregate
{
    public class Customer : User
    {
        public Customer(string firstName, string surName) : base(firstName, surName)
        {

        }

        public Customer(UserId userId, string firstName, string surName) : base(userId, firstName, surName)
        {

        }

        public CustomerDto ToDto()
        {
            var customerDto = new CustomerDto()
            {
                Id = this.Id.Id,
                FirstName = this.FirstName,
                SurName = this.SurName,
            };

            return customerDto;
        }

        public static Customer FromDto(CustomerDto customerDto)
        {
            UserId userId = !customerDto.Id.HasValue ? new UserId() : UserId.FromGuid(customerDto.Id.Value);
            var customer = new Customer(userId, customerDto.FirstName, customerDto.SurName);
            return customer;
        }
    }
}
