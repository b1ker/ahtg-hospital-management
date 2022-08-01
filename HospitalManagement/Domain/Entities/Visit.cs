using System;
namespace HospitalManagement.Domain.Entities
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }
        public Person Client { get; set; }
    }
}

