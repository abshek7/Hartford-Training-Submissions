using AutoMapper;
using AutoMapperDemo.DTOs;
using AutoMapperDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        public EmployeeController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> GetEmployee()
        {

            Employee employeeFromDb = new Employee() { Name = "Abhishek", Salary = 40000, Address = "13-195/2,kamala nagar colony medipally", Department = "Data ops" };
            //EmployeeDTO employeeDTO = new EmployeeDTO()
            //{
            //    Name = e.Name,
            //    Department=e.Department
            //};

            EmployeeDTO employeeDto=_mapper.Map<EmployeeDTO>(employeeFromDb);
            return Ok(employeeDto);


        }
    }
}
