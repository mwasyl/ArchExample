using Trip.Core.Ports.Driven;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Exceptions;

namespace Trip.Core.Services
{
    public class TravelDomainService : ITravelDomainService
    {
        private ITravelRepository _travelRepository;

        public TravelDomainService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public void CreateTravel(Travel travel)
        {
            _travelRepository.Save(travel);
        }

        public void AssignCustomer(Travel travel, Customer customer)
        {
            if (travel == null)
            {
                throw new TravelException("Cannot assign Customer. Travel is null");
            }
            else
            {
                travel.AssignCustomer(customer);
            }
        }

        public void EditTravel(Travel travel)
        {
            _travelRepository.Save(travel);
        }
    }
}
