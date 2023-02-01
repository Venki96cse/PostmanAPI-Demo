using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostmanAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {Id= 1,
            Name="Venkat",
            Address = "Chennai",
            Dept= "it"
            },
            new Employee()
            {Id= 2,
            Name="Rajesh",
            Address = "Chennai",
            Dept= "Infra"
            },
            new Employee()
            {Id= 3,
            Name="Akhil",
            Address = "Bangalore",
            Dept= "HR"
            },
            new Employee()
            {Id= 4,
            Name="Surendar",
            Address = "Mumbhai",
            Dept= "BA"
            }
        };

        public EmployeeController() { }



        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployeeDetails(int id)
        {
            var emp = employees.Find(x => x.Id == id);
            if (emp == null)
                return BadRequest("Record not found");
            return Ok(emp);
        }

        [HttpPost]
        [Route("PostEmployee")]
        public async Task<IActionResult> PostEmployeeDetails(Employee employee)
        {
            employees.Add(employee);
            if (employees == null)
                return BadRequest("Employee record not posted");
            return Ok(employees);
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public async Task<IActionResult> UpdateEmployeeDetails(Employee employee)
        {
            var emp = employees.Find(x => x.Id == employee.Id);
            if (emp == null)
                return BadRequest("Record not found");

            emp.Name = employee.Name;
            emp.Address = employee.Address;
            emp.Dept = employee.Dept;

            return Ok(employees);
        }

    }
}
