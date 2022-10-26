using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeVacationsController : ControllerBase
    {
        private readonly IEmployeeVacationService _service;
        public EmployeeVacationsController(IEmployeeVacationService employeeVacation)
        {
            _service = employeeVacation;
        }

        // GET: api/EmployeeVacations
        [HttpGet]
        public IEnumerable<EmployeeVacationDTO> GetEmployeeVacation()
        {
            return _service.GetAll();
        }

        // GET: api/EmployeeVacations/5
        [HttpGet("{id}")]
        public IEnumerable<EmployeeVacationDTO> GetEmployeeVacation(int id)
        {
            return _service.GetById(id);
        }

        // PUT: api/EmployeeVacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutEmployeeVacation(int id, EmployeeDataVcationsDTO EmployeeVacation)
        {
            _service.PutEmployeeVacation(id, EmployeeVacation);

        }

        // POST: api/EmployeeVacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostEmployeeVacation(EmployeeVacationDTOPOST employeeVacation)
        {
            _service.add(employeeVacation);
        }

        // DELETE: api/EmployeeVacations/5
        [HttpDelete("{id}")]
        public void DeleteEmployeeVacation(int id)
        {
            _service.delete(id);

        }

        private bool EmployeeVacationExists(int id)
        {
            return false;
        }
    }

}
