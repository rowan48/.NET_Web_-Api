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
    public class VacationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVacationMapper _VacationMapper;


        public VacationsController(DataContext context, IVacationMapper vacationMapper)
        {
            _context = context;
            _VacationMapper = vacationMapper;
        }

        // GET: api/Vacations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacationDTO>>> GetVacation()
        {
            List<Vacation> vacations = await _context.Vacation.ToListAsync();
            List<VacationDTO> result = new List<VacationDTO>();
            foreach (Vacation vac in vacations)
            {
                result.Add(_VacationMapper.ConvertVacationToVacationDTO(vac));

            }

            return result;


        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacationDTO>> GetVacation(int id)
        {

            VacationDTO vacation =
                            (from vacations in _context.Vacation
                             where vacations.VacationId == id
                             select new VacationDTO
                             {
                                 VacationId = vacations.VacationId,
                                 VacationName = vacations.VacationName,
                                 Balance = vacations.Balance,




                             }).FirstOrDefault();

            if (vacation == null)
            {
                return NotFound();
            }
            return vacation;
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacation(int id, VacationDTO vacationDTO)
        {

            Vacation vacation = _VacationMapper.ConvertVacationDTOToVacation(vacationDTO);
            EmployeeVacation employeeVacation = new EmployeeVacation()
            {
                VacationID = vacation.VacationId,
                EmployeeUsedVacation = 0,
                EmployeeBalance = vacation.Balance

            };
            if (id != vacation.VacationId)
            {
                return BadRequest();
            }

            _context.Entry(vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
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

        // POST: api/Vacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VacationDTO>> PostVacation(VacationDTO vacationDTO)
        {

            Vacation fetchedVac = _VacationMapper.ConvertVacationDTOToVacation(vacationDTO);


            _context.Vacation.Add(fetchedVac);
            await _context.SaveChangesAsync();
            VacationDTO vacationDTO1 = _VacationMapper.ConvertVacationToVacationDTO(fetchedVac);


            return CreatedAtAction("GetVacation", new { id = vacationDTO1.VacationId }, vacationDTO1);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacation(int id)
        {
            var vacation = await _context.Vacation.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _context.Vacation.Remove(vacation);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("{vacationID}/CheckVacationEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeVacationDTO>>> CheckVacationEmployees(int vacationID)
        {

            List<EmployeeVacationDTO> result = new List<EmployeeVacationDTO>();



            var output = from emp in _context.Employee
                         join empvac in _context.EmployeeVacation
                         on emp.EmployeeId equals empvac.EmployeeID
                         join vac in _context.Vacation
                         on empvac.VacationID equals vac.VacationId
                         into all
                         from values in all.DefaultIfEmpty()
                         where values.VacationId == vacationID

                         select new
                         {
                             name = emp.FullName,
                             balance = empvac.EmployeeBalance,
                             vacno = vacationID == null ? 0 : empvac.VacationID


                         };















            return Ok(output);
        }


        private bool VacationExists(int id)
        {
            return _context.Vacation.Any(e => e.VacationId == id);
        }
    }
}
