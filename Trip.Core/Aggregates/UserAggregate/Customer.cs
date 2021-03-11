namespace Trip.Core.Aggregates.UserAggregate
{
    public class Customer : User
    {
        public Customer(string firstName, string surName) : base(firstName, surName)
        {
        }

        public Customer(UserId userId, string firstName, string surName) : base(userId, firstName, surName)
        {
        }
    }
}
