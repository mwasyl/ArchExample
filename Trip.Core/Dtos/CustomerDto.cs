using System;

namespace Trip.Core.Dtos
{
    public class CustomerDto
    {
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
