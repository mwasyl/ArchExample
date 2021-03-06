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

        public Guid Id { get; private set; }
    }
}
