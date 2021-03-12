using System.Collections.Generic;
using System.Threading.Tasks;
using Trip.Core.Aggregates.TripAggregate;

namespace Trip.Core.Ports.Driven
{
    public interface ITravelRepository
    {
        Task<IReadOnlyCollection<Travel>> Get();
        Task<Travel> Get(TravelId id);
        Task Create(Travel travel);
        Task Update(Travel travel);
    }
}
