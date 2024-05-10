using AutoMapper;
using Frist_API_Project.Models;
using Frist_API_Project.Models.DatatTransfareObject;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Frist_API_Project
{
    public class MappingConfig:Profile
    {
        public MappingConfig() 
        {
            CreateMap<Employee , EmployeeDto>().ReverseMap();
            CreateMap<Employee , UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

        }
    }
}
