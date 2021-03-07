using Trip.Core.Common;
using Trip.Core.Exceptions;

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

        public void Edit(User editedUser)
        {
            FirstName = editedUser.FirstName;
            SurName = editedUser.SurName;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                throw new UserException("User error. First name is null.");

            if (string.IsNullOrEmpty(SurName))
                throw new UserException("User error. Surname is null.");
        }
    }
}
