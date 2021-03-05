using System;
using Trip.Core.Common;

namespace Trip.Core.TripAggregate
{
    public class TripId : ValueObject
    {
        public Guid Id { get; set; }
    }
}
