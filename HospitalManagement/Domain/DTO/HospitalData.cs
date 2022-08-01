using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Domain.Dto
{
    public class HospitalData
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

        public AddressData? Address { get; set; }
    }
}
