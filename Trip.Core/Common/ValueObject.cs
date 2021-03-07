
namespace Trip.Core.Common
{
    /// <summary>
    /// Implementation based on:
    /// https://docs.microsoft.com/pl-pl/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// </summary>
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this == other;
        }

        public override int GetHashCode()
        {
            return this != null ? this.GetHashCode() : 0;
        }
    }
}
