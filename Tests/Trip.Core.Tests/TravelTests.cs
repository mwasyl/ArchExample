using System;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Exceptions;
using Xunit;

namespace Trip.Core.Tests
{
    public class TravelTests
    {
        [Fact]
        public void Customer_Should_Be_Assigned_To_Travel()
        {
            //arrange
            Travel travel = new Travel(new TravelId(), "Lodz");
            Customer customer = new Customer("John", "Smith");

            //act
            travel.AssignCustomer(customer);

            //assert
            Assert.Equal(customer, travel.Customer);
        }

        [Fact]
        public void Assigning_Customer_Should_Throw_Exception_When_Customer_Is_Null()
        {
            //arrange
            Travel travel = new Travel(new TravelId(), "Lodz");
            Customer customer = null;

            //act and assert
            Assert.Throws<TravelException>(() => travel.AssignCustomer(customer));
        }

        [Fact]
        public void Assigning_Customer_Should_Throw_Exception_When_Travel_Is_Cancelled()
        {
            //arrange
            Travel travel = new Travel(new TravelId(), "Lodz");
            travel.Cancel();
            Customer customer = new Customer("John", "Smith");

            //act and assert
            Assert.Throws<TravelException>(() => travel.AssignCustomer(customer));
        }


        [Fact]
        public void Travel_Should_Be_Editted()
        {
            //arrange
            Travel travel = new Travel(new TravelId(), "Lodz");
            Travel travelEdited = new Travel(new TravelId(), "Warsaw");

            //act
            travel.Edit(travelEdited);

            //assert
            Assert.Equal("Warsaw", travel.Destination);
        }

        [Fact]
        public void Travel_Should_Be_Cancelled()
        {
            //arrange
            Travel travel = new Travel(new TravelId(), "Lodz");
            Customer customer = new Customer("John", "Smith");

            //act
            travel.Cancel();

            //assert
            Assert.True(travel.IsCancel);
        }
    }
}
