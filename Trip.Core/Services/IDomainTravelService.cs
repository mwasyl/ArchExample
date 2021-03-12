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
        Task EditTravel(Guid travelId, Travel editedTravel);
        Task AssignCustomer(TravelId travelId, UserId customerId);
        Task Cancel(TravelId travelId);
    }
}
