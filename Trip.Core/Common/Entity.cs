namespace Trip.Core.Common
{
    public abstract class Entity<T> where T: ValueObject
    {
        public T Id { get; set; }
    }
}
