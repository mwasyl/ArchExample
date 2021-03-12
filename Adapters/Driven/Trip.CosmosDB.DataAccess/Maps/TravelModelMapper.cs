using System.Collections.Generic;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.CosmosDB.DataAccess.Models;

namespace Trip.CosmosDB.DataAccess.Maps
{
    public static class TravelModelMapper
    {
        public static Travel FromDalModel(TravelDal travelDal)
        {
            List<Customer> customers = new List<Customer>();
            if (travelDal.Customers != null && travelDal.Customers.Count > 0)
            {
                foreach (var customer in travelDal.Customers)
                {
                    customers.Add(new Customer(UserId.FromString(customer.Id), customer.FirstName, customer.SurName));
                }
            }

            return new Travel(TravelId.FromString(travelDal.Id), travelDal.Destination, customers);
        }
        public static TravelDal FromDomainModel(Travel travel)
        {
            var travelDal = new TravelDal()
            {
                Id = travel.Id.Id.ToString(),
                Destination = travel.Destination,
                IsCancel = travel.IsCancel,
                Customers = new List<CustomerDal>()
            };

            if (travel.Customers != null && travel.Customers.Count > 0)
            {
                foreach(var customer in travel.Customers)
                {
                    travelDal.Customers.Add(new CustomerDal()
                    {
                        Id = customer.Id.Id.ToString(),
                        FirstName = customer.FirstName,
                        SurName = customer.SurName
                    });
                }
            }

            return travelDal;
        }
    }
}
