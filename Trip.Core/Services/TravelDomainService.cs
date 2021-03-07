using Trip.Core.Ports.Driven;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        public async Task<IReadOnlyCollection<Travel>> GetTravels()
        {
            return await _travelRepository.Get();
        }

        public void Cancel(Travel travel)
        {
            travel.Cancel();
        }

        public void EditTravel(Guid travelId, Travel editedTravel)
        {
            Travel travel = _travelRepository.Get(TravelId.FromGuid(travelId)).GetAwaiter().GetResult();
            travel.Edit(editedTravel);
            _travelRepository.Save(travel);
        }
    }
}
