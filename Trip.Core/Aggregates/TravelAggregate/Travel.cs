using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Common;
using Trip.Core.Exceptions;

namespace Trip.Core.Aggregates.TripAggregate
{
    public class Travel : Entity<TravelId>
    {
        public Travel(string destination)
        {
            Id = new TravelId();
            Destination = destination;
        }

        public string Destination { get; private set; }
        public Customer Customer { get; private set; }

        public void AssignCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new TravelException("Cannot assign Customer. It's null.");
            } else
            {
                Customer = customer;
            }
        }
    }
}
