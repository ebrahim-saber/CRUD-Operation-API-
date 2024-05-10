using System.ComponentModel.DataAnnotations;

namespace Frist_API_Project.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public IList<Employee>? Employees { get; set; }
    }
}
