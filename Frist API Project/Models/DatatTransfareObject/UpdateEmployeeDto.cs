using System.ComponentModel.DataAnnotations;

namespace Frist_API_Project.Models.DatatTransfareObject
{
    public class UpdateEmployeeDto
    {
        //I'ill use this class to transfare data;

        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }
        [Required]
        public int departmentId { get; set; }

    }
}
