using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Ports.Driven;

namespace Trip.InMemoryDataAccess
{
    public class TravelInMemoryRepository : ITravelRepository
    {
        private List<Travel> _travels = new List<Travel>
            {
                new Travel("Lodz"),
                new Travel("Warsaw"),
                new Travel("Kielce"),
            };

        public Task<IReadOnlyCollection<Travel>> Get()
        {
            return Task.FromResult<IReadOnlyCollection<Travel>>(_travels);
        }

        public Task<Travel> Get(TravelId id)
        {
            throw new NotImplementedException();
        }

        public void Save(Travel travel)
        {
            throw new NotImplementedException();
        }
    }
}
