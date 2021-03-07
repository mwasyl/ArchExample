using Trip.Core.Aggregates.UserAggregate;
using Xunit;

namespace Trip.Core.Tests
{
    public class UserTests
    {
        [Fact]
        public void Customer_Should_Be_Edited()
        {
            //arrange
            Customer customer = new Customer("John", "Smith");
            Customer customerEdited = new Customer("John2", "Smith2");

            //act
            customer.Edit(customerEdited);

            //assert
            Assert.Equal("John2", customer.FirstName);
            Assert.Equal("Smith2", customer.SurName);
        }
    }
}