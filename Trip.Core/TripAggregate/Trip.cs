using Trip.Core.Common;

namespace Trip.Core.TripAggregate
{
    public class Trip : Entity<TripId>
    {
        public string Destination { get; private set; }
    }
}
