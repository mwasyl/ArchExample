using System;

namespace Trip.Core.Common
{
    /// <summary>
    /// Implementation based on:
    /// https://docs.microsoft.com/pl-pl/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Entity<T> where T: ValueObject
    {
        public T Id { get; set; }

        
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<T>))
                return false;
            if (Object.ReferenceEquals(this, obj))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            Entity<T> item = (Entity<T>)obj;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Entity<T> left, Entity<T> right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null));
            else
                return left.Equals(right);
        }
        public static bool operator !=(Entity<T> left, Entity<T> right)
        {
            return !(left == right);
        }
    }
}
