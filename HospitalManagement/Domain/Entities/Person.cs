using System;
namespace HospitalManagement.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public bool IsDoctor { get; set; }
    }
}

