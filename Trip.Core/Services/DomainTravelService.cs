using Trip.Core.Ports.Driven;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;
using Trip.Core.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Trip.Core.Services
{
    public class DomainTravelService : IDomainTravelService
    {
        private ITravelRepository _travelRepository;
        private ICustomerRepository _customerRepository;

        public DomainTravelService(ITravelRepository travelRepository, 
            ICustomerRepository customerRepository)
        {
            _travelRepository = travelRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IReadOnlyCollection<Travel>> GetTravels()
        {
            return await _travelRepository.Get();
        }

        public async Task<Travel> GetTravel(TravelId travelId)
        {
            return await _travelRepository.Get(travelId);
        }

        public async Task CreateTravel(Travel travel)
        {
            await _travelRepository.Create(travel);
        }

        public async Task EditTravel(Guid travelId, Travel editedTravel)
        {
            Travel travel = await _travelRepository.Get(TravelId.FromGuid(travelId));
            travel.Edit(editedTravel);
            await _travelRepository.Update(travel);
        }

        public async Task Cancel(TravelId travelId)
        {
            var travel = await _travelRepository.Get(travelId);
            travel.Cancel();
        }

        public async Task AssignCustomer(TravelId travelId, UserId customerId)
        {
            var travel = await _travelRepository.Get(travelId);
            var customer = await _customerRepository.Get(customerId);
            
            if (travel == null)
            {
                throw new TravelException("Cannot assign Customer. Travel is null");
            }
            else
            {
                travel.AssignCustomer(customer);
                await _travelRepository.Update(travel);
            }
        }
    }
}
