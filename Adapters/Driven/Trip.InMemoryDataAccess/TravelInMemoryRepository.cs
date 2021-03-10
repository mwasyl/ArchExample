using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;
using Trip.Core.Ports.Driven;

namespace Trip.InMemoryDataAccess
{
    public class TravelInMemoryRepository : ITravelRepository
    {
        private List<Travel> _travels = new List<Travel>
            {
                new Travel(TravelId.FromGuid(Guid.Parse("b12d9364-2753-4e40-a131-4ba7144041dd")), "Lodz"),
                new Travel(TravelId.FromGuid(Guid.Parse("7be74db4-e6b0-4b49-8ed4-376a315c8d98")), "Warsaw"),
                new Travel(TravelId.FromGuid(Guid.Parse("0048202b-7f28-4e29-bb5f-f76ba8291128")), "Kielce"),
            };

        public Task<IReadOnlyCollection<Travel>> Get()
        {
            return Task.FromResult<IReadOnlyCollection<Travel>>(_travels);
        }

        public Task<Travel> Get(TravelId id)
        {
            return Task.FromResult(_travels.SingleOrDefault(p => p.Id.Equals(id))); //TODO: to use custom made equals operator in value object
        }

        public void Save(Travel travel)
        {
            throw new NotImplementedException();
        }
    }
}
