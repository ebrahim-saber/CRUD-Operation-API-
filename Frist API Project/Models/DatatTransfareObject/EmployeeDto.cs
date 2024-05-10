namespace Frist_API_Project.Models.DatatTransfareObject
{
    public class EmployeeDto
    {
        //I'ill use this class to transfare data;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? street { get; set; }
        public int departmentId { get; set; }

    }
}
