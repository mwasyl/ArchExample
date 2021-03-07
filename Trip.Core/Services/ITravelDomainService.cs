using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Aggregates.UserAggregate;

namespace Trip.Core.Services
{
    public interface ITravelDomainService
    {
        Task<IReadOnlyCollection<Travel>> GetTravels();
        void CreateTravel(Travel travel);
        void EditTravel(Guid travelId, Travel editedTravel);
        void AssignCustomer(Travel travel, Customer customer);
        void Cancel(Travel travel);
    }
}
