using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;

namespace Trip.Core.Services
{
    public interface ITravelDomainService
    {
        void CreateTravel(Travel travel);
        void AssignCustomer(Travel travel, Customer customer);
        void EditTravel(Travel travel);
    }
}
