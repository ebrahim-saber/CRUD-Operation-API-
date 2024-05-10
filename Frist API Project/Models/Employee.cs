using System.ComponentModel.DataAnnotations.Schema;

namespace Frist_API_Project.Models
{
    public class Employee
    {
        //I'ill use this class to be mapping between me and database;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }

        public int departmentId { get; set; }
        public Department? department { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
