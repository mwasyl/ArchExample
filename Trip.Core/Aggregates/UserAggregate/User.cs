using Trip.Core.Common;

namespace Trip.Core.Aggregates.UserAggregate
{
    public abstract class User : Entity<UserId>
    {
        public User(string firstName, string surName)
        {
            FirstName = firstName;
            SurName = surName;
            Id = new UserId();
        }

        public string FirstName { get; private set; }
        public string SurName { get; private set; }
    }
}
