using Trip.Core.Aggregates.UserAggregate;
using Trip.CosmosDB.DataAccess.Models;

namespace Trip.CosmosDB.DataAccess.Maps
{
    public static class CustomerModelMapper
    {
        public static Customer FromDalModel(CustomerDal customerDal)
        {
            return new Customer(UserId.FromString(customerDal.Id), customerDal.FirstName, customerDal.SurName);
        }
        public static CustomerDal FromDomainModel(Customer customer)
        {
            return new CustomerDal()
            {
                Id = customer.Id.ToString(),
                FirstName = customer.FirstName,
                SurName = customer.SurName
            };
        }
    }
}
