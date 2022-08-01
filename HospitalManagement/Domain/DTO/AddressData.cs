using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Domain.Dto
{
    public class AddressData
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? ZipCode { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? City { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? State { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public string ToString()
        {
            return $"{AddressLine1}, {City}, {State}, {ZipCode}";
        }
    }
}

