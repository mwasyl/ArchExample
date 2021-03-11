using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;

namespace Trip.Core.Services
{
    public interface IDomainTravelService
    {
        Task<IReadOnlyCollection<Travel>> GetTravels();
        Task<Travel> GetTravel(TravelId travel);
        Task CreateTravel(Travel travel);
        void EditTravel(Guid travelId, Travel editedTravel);
        void AssignCustomer(TravelId travelId, UserId customerId);
        void Cancel(TravelId travelId);
    }
}
