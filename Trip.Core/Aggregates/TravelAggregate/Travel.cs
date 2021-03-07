using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Common;
using Trip.Core.Dtos;
using Trip.Core.Exceptions;

namespace Trip.Core.Aggregates.TripAggregate
{
    public class Travel : Entity<TravelId>
    {
        public Travel(string destination)
        {
            Id = new TravelId();
            Destination = destination;
            IsCancel = false;
        }

        public string Destination { get; private set; }
        public Customer Customer { get; private set; }
        public bool IsCancel { get; private set; }

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

        public void Cancel()
        {
            IsCancel = true;
        }

        public TravelDto ToDto()
        {
            return new TravelDto()
            {
                Id = Id.Id,
                Destination = Destination
            };
        }

        public void Edit(Travel editedTravel)
        {
            Destination = editedTravel.Destination;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Destination))
                throw new TravelException("Travel error. Destination is null.");
        }
    }
}
