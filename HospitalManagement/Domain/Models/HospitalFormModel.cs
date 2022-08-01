using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Domain.Models
{
    public class HospitalFormModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Description { get; set; }

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
    }
}

