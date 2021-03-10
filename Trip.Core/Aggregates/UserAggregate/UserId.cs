using System;
using System.Collections.Generic;
using Trip.Core.Common;

namespace Trip.Core.Aggregates.UserAggregate
{
    public class UserId : ValueObject
    {
        public UserId()
        {
            Id = Guid.NewGuid();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public Guid Id { get; private set; }
    }
}
