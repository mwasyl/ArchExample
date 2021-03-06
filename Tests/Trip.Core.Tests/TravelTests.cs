using System;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Xunit;

namespace Trip.Core.Tests
{
    public class TravelTests
    {
        [Fact]
        public void Customer_Should_Be_Assigned_To_Travel()
        {
            //arrange
            Travel travel = new Travel("Lodz");
            Customer customer = new Customer("John", "Smith");

            //act
            travel.AssignCustomer(customer);

            //assert
            Assert.Equal(customer, travel.Customer);
        }
    }
}
