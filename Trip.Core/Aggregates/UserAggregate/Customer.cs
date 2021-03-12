using System;
using System.Collections.Generic;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Dtos;

namespace Trip.Core.Aggregates.UserAggregate
{
    public class Customer : User
    {
        public Customer(string firstName, string surName) : base(firstName, surName)
        {
            Travels = new List<Travel>();
        }

        public Customer(UserId userId, string firstName, string surName) : base(userId, firstName, surName)
        {
            Travels = new List<Travel>();
        }

        public List<Travel> Travels { get; private set; }
        
        public void AssignToTravel(Travel travel)
        {
            Travels.Add(travel);
        }

        public CustomerDto ToDto()
        {
            var customerDto = new CustomerDto()
            {
                Id = this.Id.Id,
                FirstName = this.FirstName,
                SurName = this.SurName,
                Travels = new List<TravelDto>()
            };

            foreach(var travel in Travels)
            {
                customerDto.Travels.Add(travel.ToDto());
            }

            return customerDto;
        }

        public static Customer FromDto(CustomerDto customerDto)
        {
            if (customerDto.Id == null)
            {
                customerDto.Id = Guid.NewGuid();
            }
            var customer = new Customer(new UserId(customerDto.Id), customerDto.FirstName, customerDto.SurName);

            if (customerDto.Travels == null)
            {
                customerDto.Travels = new List<TravelDto>();
            }

            foreach(var travelDto in customerDto.Travels)
            {
                customer.Travels.Add(Travel.FromDto(travelDto));
            }

            return customer;
        }
    }
}
