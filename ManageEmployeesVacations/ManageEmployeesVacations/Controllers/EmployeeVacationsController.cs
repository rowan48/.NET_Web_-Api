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
    public class EmployeeVacationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IEmployeeVacationMapper _mapper;
        private readonly IEmployeeVacationDTOPOSTMapper _employeeVacationDTOPOSTMapper;

        public EmployeeVacationsController(DataContext context, IEmployeeVacationMapper mapper, IEmployeeVacationDTOPOSTMapper employeeVacationDTOPOSTMapper)
        {
            _context = context;
            _mapper = mapper;
            _employeeVacationDTOPOSTMapper = employeeVacationDTOPOSTMapper;
        }

        // GET: api/EmployeeVacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeVacationDTO>>> GetEmployeeVacation()
        {
            List<EmployeeVacation> empvacations = await _context.EmployeeVacation.ToListAsync();
            List<EmployeeVacationDTO> employeeVacationDTOs = new List<EmployeeVacationDTO>();
            foreach (EmployeeVacation employeeVacationDTO in empvacations)
            {
                employeeVacationDTOs.Add(_mapper.ConvertEmployeeVacationToDTO(employeeVacationDTO));

            }
            return employeeVacationDTOs;
        }

        // GET: api/EmployeeVacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeVacationDTO>> GetEmployeeVacation(int id)
        {
            var employeeVacation = await _context.EmployeeVacation.FindAsync(id);

            if (employeeVacation == null)
            {
                return NotFound();
            }

            return _mapper.ConvertEmployeeVacationToDTO(employeeVacation);
        }

        // PUT: api/EmployeeVacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeVacation(int id, EmployeeDataVcationsDTO EmployeeVacation)
        {
            if (id != EmployeeVacation.EmployeeId)
            {
                return BadRequest();
            }


            var employee = _context.Employee
               .Where(b => b.EmployeeId == id)
               .FirstOrDefault();
            if (EmployeeVacation.FullName != null)
            {
                employee.FullName = EmployeeVacation.FullName;

            }
            if (EmployeeVacation.BirthDate != null)
            {
                employee.BirthDate = (DateTime)EmployeeVacation.BirthDate;

            }
            if (EmployeeVacation.GenderId != null)
            {
                employee.GenderId = (int)EmployeeVacation.GenderId;

            }


            if (employee.Email != null && EmployeeVacation.Email != null)
            {
                employee.Email = EmployeeVacation.Email;

            }
            var empvac = _context.EmployeeVacation
                .Where(b => b.VacationID == EmployeeVacation.VacationID && b.EmployeeID == id)
                .FirstOrDefault();
            //  empvac.EmployeeUsedVacation = EmployeeVacation.EmployeeUsedVacation;
            empvac.EmployeeBalance = EmployeeVacation.EmployeeBalance;

            _context.Entry(employee).State = EntityState.Modified;
            _context.Entry(empvac).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeVacationExists(id))
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

        // POST: api/EmployeeVacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeVacation>> PostEmployeeVacation(EmployeeVacationDTOPOST employeeVacation)
        {


            EmployeeVacation FetchedEmpVacation = _employeeVacationDTOPOSTMapper.ConvertDtoPOSTToEmployeeDataVacation(employeeVacation);

            _context.EmployeeVacation.Add(FetchedEmpVacation);

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateException)
            {
                if (EmployeeVacationExists(employeeVacation.EmployeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            EmployeeVacationDTOPOST empvacDTO = _employeeVacationDTOPOSTMapper.ConvertEmployeeDataVacationToDTOPOST(FetchedEmpVacation);

            return CreatedAtAction("GetEmployeeVacation", new { id = empvacDTO.EmployeeID }, empvacDTO);
        }

        // DELETE: api/EmployeeVacations/5
        [HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployeeVacation(int id)
        //{
        //    var employeeVacation = await _context.EmployeeVacation.FindAsync(id);
        //    if (employeeVacation == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EmployeeVacation.Remove(employeeVacation);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool EmployeeVacationExists(int id)
        {
            return _context.EmployeeVacation.Any(e => e.EmployeeID == id);
        }
    }
}
