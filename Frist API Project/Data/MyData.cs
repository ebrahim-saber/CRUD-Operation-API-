using Frist_API_Project.Models;
using Frist_API_Project.Models.DatatTransfareObject;

namespace Frist_API_Project.Data
{
    //عملت ده علشان مش هتعامل مع قاعدة البيانات حاليا
    public static class MyData
    {
        public static List<EmployeeDto> EmployeesList = new List<EmployeeDto>()
            {
                new EmployeeDto() {Id = 1 , Name = "Ali"},
                new EmployeeDto() {Id = 2 , Name ="Ibrahim"},
                new EmployeeDto() {Id = 3 , Name = " Ahmed"}
            };
        public static List<EmployeeDto> GetEmployees()
        {
            return EmployeesList;
        }
         
    }
}
