using System;

namespace Trip.Core.Exceptions
{
    public class TravelException : Exception
    {
        public TravelException(string message) : base(message)
        {

        }
    }
}
