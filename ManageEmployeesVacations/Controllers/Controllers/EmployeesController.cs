using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {

            _service = service;
        }

        //  GET: api/Employees
        [HttpGet]

        public IEnumerable<EmployeeDTO> GetEmployee()

        {

            return _service.GetEmployees();
        }




        // GET: api/Employees/5
        [HttpGet("{id}")]
        public EmployeeDTO GetEmployee(int id)
        {
            return _service.GetById(id);

        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public void PutEmployee(EmployeeDTO employeeDto)
        {
            _service.updateEmployee(employeeDto);

        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostEmployee(EmployeeDTO employee)
        {
            _service.postEmployee(employee);

        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            _service.deleteEmployee(id);

        }

        [HttpGet("{employeeID}/checkBalance")]
        public IEnumerable<EmployeeVacationDTO> CheckBalance(int employeeID)
        {

            return _service.CheckBalance(employeeID);

        }


        private bool EmployeeExists(int id)
        {
            return false;
        }
    }
}
