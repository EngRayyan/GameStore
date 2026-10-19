//using HRMS.Dtos.Employee;
//using HRMS.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HRMS.Controllers
//{
//    // Data Annotations => Class, Methods, Properties, Parameters
//    [Route("api/[controller]")] // api/Employees
//    [ApiController]
//    public class EmployeesController : ControllerBase
//    {
//        public EmployeesController()
//        {
//            Console.WriteLine();
//        }

//        // Mock Data
//        public static List<Employee> employees = new List<Employee>
//        {
//            new Employee { Id = 1, FirstName = "Ahmad", LastName="Nasser", Email="Ahmad@123",
//                Position = "Developer", BirthDate = new DateTime(1995,1,25), PhoneNumber = "+96279545135",
//                IsActive = true, StartDate = new DateTime(), Salary = 1000
//            },
//            new Employee(){ Id = 2, FirstName = "Layla", LastName = "Kareem", Email = "Layla@123.com",
//                Position = "HR", BirthDate = new DateTime(2000,1,25), PhoneNumber = "+9625588625",
//                IsActive = true, StartDate = new DateTime(2026, 1, 1), Salary = 1000},

//            new Employee(){ Id = 3, FirstName = "Yousef", LastName = "Faris", Email = "Yousef@123.com",
//                Position = "Manager", BirthDate = new DateTime(1996,1,25), PhoneNumber = "+9625588625",
//                IsActive = true, StartDate = new DateTime(2026, 1, 1), Salary = 1200},

//            new Employee(){ Id = 4, FirstName = "Nadia", LastName = "Zaid", Email = "Nadia@123.com",
//                Position = "Developer", BirthDate = new DateTime(1999,1,25), PhoneNumber = "+9625588625",
//                IsActive = true, StartDate = new DateTime(2026, 1, 1), Salary = 800}

//        };

//        [HttpGet]
//        public IActionResult GetByCriteria(string? position, string? name)
//        {
//            var data = from emp in employees
//                       where (position == null || emp.Position.ToUpper().Contains(position.ToUpper())) &&
//                             (name == null || emp.FirstName.ToUpper().Contains(name.ToUpper()))
//                       orderby emp.Id descending
//                       select new EmployeeDto
//                       {
//                           Id = emp.Id,
//                           FullName = emp.FirstName + " " + emp.LastName,
//                           Position = emp.Position,
//                           BirthDate = emp.BirthDate,
//                           StartDate = emp.StartDate,
//                           EndDate = emp.EndDate,
//                           Salary = emp.Salary
//                       };

//            return Ok(data);
//        }

//        [HttpGet("GetById")]
//        public IActionResult GetById(long id)
//        {

//            var data = employees.Select(x => new EmployeeDto
//            {
//                Id = x.Id,
//                FullName = x.FirstName + " " + x.LastName,
//                Position = x.Position,
//                BirthDate = x.BirthDate,
//                StartDate = x.StartDate,
//                EndDate = x.EndDate,
//                Salary = x.Salary
//            }).FirstOrDefault(x => x.Id == id);

//            if (data == null)
//            {
//                return NotFound(new Exception("Employee Not Found")); // 404
//            }

//            return Ok(data);
//        }

//        [HttpPost]
//        public IActionResult Create(SaveEmployeeDto employeeDto)
//        {
//            var employee = new Employee
//            {
//                Id = employees.LastOrDefault().Id + 1,
//                FirstName = employeeDto.FirstName,
//                LastName = employeeDto.LastName,
//                Position = employeeDto.Position,
//                BirthDate = employeeDto.BirthDate,
//                StartDate = employeeDto.StartDate,
//                EndDate = employeeDto.EndDate,
//                Email = employeeDto.Email,
//                IsActive = employeeDto.IsActive,
//                PhoneNumber = employeeDto.PhoneNumber,
//                Salary = employeeDto.Salary
//            };

//            employees.Add(employee);
//            return Ok(employee.Id);
//        }
//    }


//}