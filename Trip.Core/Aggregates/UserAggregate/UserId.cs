using System;
using Trip.Core.Common;

namespace Trip.Core.Aggregates.UserAggregate
{
    public class UserId : ValueObject
    {
        public UserId()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
