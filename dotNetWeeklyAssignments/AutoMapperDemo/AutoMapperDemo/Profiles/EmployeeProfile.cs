using AutoMapper;
using AutoMapperDemo.DTOs;
using AutoMapperDemo.Models;

namespace AutoMapperDemo.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();

        }
    }
}
