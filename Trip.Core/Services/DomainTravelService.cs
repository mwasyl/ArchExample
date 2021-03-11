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

        public Task CreateTravel(Travel travel)
        {
            _travelRepository.Save(travel);
            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<Travel>> GetTravels()
        {
            return await _travelRepository.Get();
        }

        public async void Cancel(TravelId travelId)
        {
            var travel = await _travelRepository.Get(travelId);
            travel.Cancel();
        }

        public void EditTravel(Guid travelId, Travel editedTravel)
        {
            Travel travel = _travelRepository.Get(TravelId.FromGuid(travelId)).GetAwaiter().GetResult();
            travel.Edit(editedTravel);
            _travelRepository.Save(travel);
        }

        public Task<Travel> GetTravel(TravelId travelId)
        {
            return _travelRepository.Get(travelId);
        }

        public async void AssignCustomer(TravelId travelId, UserId customerId)
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
            }
        }
    }
}
