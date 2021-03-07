using System;
using Trip.Core.Common;

namespace Trip.Core.Aggregates.TripAggregate
{
    public class TravelId : ValueObject
    {
        public TravelId()
        {
            Id = Guid.NewGuid();
        }

        public static TravelId FromGuid(Guid id)
        {
            return new TravelId() { Id = id };
        }

        public Guid Id { get; private set; }
    }
}
