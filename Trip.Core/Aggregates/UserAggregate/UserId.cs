﻿using System;
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

        public UserId(Guid id)
        {
            Id = id;
        }

        public static UserId FromGuid(Guid id)
        {
            return new UserId() { Id = id };
        }

        public static UserId FromString(string id)
        {
            return new UserId() { Id = Guid.Parse(id) };
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }

        public Guid Id { get; private set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
