using ManageEmployeesVacations.Data;
using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Mappers;
using ManageEmployeesVacations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesVacations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEmployeeMapper _employeeMapper;
        private readonly IEmployeeVacationMapper _employeeVacationMapper;

        public EmployeesController(DataContext context, IEmployeeMapper employeeMapper, IEmployeeVacationMapper employeeVacationMapper)
        {
            _employeeMapper = employeeMapper;
            _employeeVacationMapper = employeeVacationMapper;
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]

        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployee()
        {




            List<EmployeeDTO> empgender =
          (from anemp in _context.Employee
           join gend in _context.Gender
          on anemp.GenderId equals gend.GenderId

           select new EmployeeDTO
           {
               EmployeeId = anemp.EmployeeId,
               Email = anemp.Email,
               FullName = anemp.FullName,
               BirthDate = anemp.BirthDate,
               GenderName = gend.GenderType,
               GenderId = gend.GenderId,


           }).ToList();


            return empgender;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {

            EmployeeDTO empgender =
        (from anemp in _context.Employee
         join gend in _context.Gender
        on anemp.GenderId equals gend.GenderId
         where (anemp.EmployeeId == id)
         select new EmployeeDTO
         {

             EmployeeId = anemp.EmployeeId,
             Email = anemp.Email,
             FullName = anemp.FullName,
             BirthDate = anemp.BirthDate,
             GenderName = gend.GenderType,
             GenderId = gend.GenderId,


         }).FirstOrDefault();


            if (empgender == null)
            {
                return NotFound();
            }
            //_employeeMapper.ConvertEmpToEmpDTO(employee)

            return empgender;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDto)
        {
            Employee employee = _employeeMapper.ConvertEmpDTOToEmp(employeeDto);
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO employee)
        {

            Employee fetchedEmp = _employeeMapper.ConvertEmpDTOToEmp(employee);


            List<Vacation> vacations = await _context.Vacation.ToListAsync();
            List<EmployeeVacation> employeeVacations = new List<EmployeeVacation>();
            foreach (Vacation vacation in vacations)
            {
                EmployeeVacation employeeVacation = new EmployeeVacation()
                {
                    VacationID = vacation.VacationId,
                    EmployeeUsedVacation = 0,
                    EmployeeBalance = vacation.Balance

                };
                employeeVacations.Add(employeeVacation);
            }

            fetchedEmp.EmployeeVacations = employeeVacations;

            _context.Employee.Add(fetchedEmp);
            await _context.SaveChangesAsync();


            EmployeeDTO fetchedEmpDTO = (from anemp in _context.Employee
                                         join gend in _context.Gender
                                        on anemp.GenderId equals gend.GenderId
                                         where (anemp.EmployeeId == fetchedEmp.EmployeeId)
                                         select new EmployeeDTO
                                         {

                                             EmployeeId = anemp.EmployeeId,
                                             Email = anemp.Email,
                                             FullName = anemp.FullName,
                                             BirthDate = anemp.BirthDate,
                                             GenderName = gend.GenderType,
                                             GenderId = gend.GenderId,


                                         }).FirstOrDefault();


            return CreatedAtAction("GetEmployee", new { id = fetchedEmpDTO.EmployeeId }, fetchedEmpDTO);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{employeeID}/checkBalance")]
        public async Task<ActionResult<IEnumerable<EmployeeVacationDTO>>> CheckBalance(int employeeID)
        {

            List<EmployeeVacationDTO> result = new List<EmployeeVacationDTO>();

            var employeeVacations = (from empvac in _context.EmployeeVacation
                                     join vacations in _context.Vacation
                                      on empvac.VacationID equals vacations.VacationId
                                     join emp in _context.Employee on empvac.EmployeeID equals emp.EmployeeId into all
                                     from values in all.DefaultIfEmpty()
                                     where empvac.EmployeeID == employeeID
                                     select new
                                     {

                                         empid = empvac.EmployeeID,
                                         vacid = empvac.VacationID,
                                         balance = empvac.EmployeeBalance,
                                         used = empvac.EmployeeUsedVacation,
                                         vacname = vacations.VacationName,

                                     }).ToList();




















            return Ok(employeeVacations);
        }

        [HttpGet("{employeeID}/checkVacationsEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeVacationDTO>>> checkVacationsEmployee(int employeeID)
        {

            List<EmployeeVacationDTO> result = new List<EmployeeVacationDTO>();





            var leftouterjoin = from vacations in _context.Vacation
                                join empvac in _context.EmployeeVacation
                                on new { vacid = vacations.VacationId, empid = employeeID } equals new { vacid = empvac.VacationID, empid = empvac.EmployeeID }


                                into a
                                from val in a.DefaultIfEmpty()
                                select new
                                {
                                    vacname = val != null ? vacations.VacationName : "-",
                                    balance = val != null ? val.EmployeeBalance : 0.0,
                                    used = val != null ? val.EmployeeUsedVacation : 0.0


                                };




            return Ok(leftouterjoin);
        }




        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
    }
}
