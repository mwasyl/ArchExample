using System;
using System.Collections.Generic;
using Trip.Core.Common;

namespace Trip.Core.Aggregates.TripAggregate
{
    public class TravelId : ValueObject
    {
        public TravelId()
        {
            Id = Guid.NewGuid();
        }

        public TravelId(Guid id)
        {
            Id = id;
        }

        public static TravelId FromGuid(Guid id)
        {
            return new TravelId() { Id = id };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public Guid Id { get; private set; }
    }
}
