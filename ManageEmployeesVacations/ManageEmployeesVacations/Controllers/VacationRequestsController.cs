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
    public class VacationRequestsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IVacationRequestMapper _VacationRequestMapper;

        public VacationRequestsController(DataContext context, IVacationRequestMapper vacationRequestMapper)
        {
            _context = context;
            _VacationRequestMapper = vacationRequestMapper;
        }

        // GET: api/VacationRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacationRequestDTO>>> GetVacationRequest()
        {
            List<VacationRequest> vacationRequests = await _context.VacationRequest.ToListAsync();
            List<VacationRequestDTO> vacationRequestDTOs = new List<VacationRequestDTO>();

            foreach (var vacationRequestDTO in vacationRequests)
            {
                vacationRequestDTOs.Add(_VacationRequestMapper.ConvertVacationRequestToVacationRequestDTO(vacationRequestDTO));
            }
            return vacationRequestDTOs;
        }

        // GET: api/VacationRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacationRequestDTO>> GetVacationRequest(int id)
        {
            var vacationRequest = await _context.VacationRequest.FindAsync(id);
            VacationRequestDTO vacationRequestDTO = _VacationRequestMapper.ConvertVacationRequestToVacationRequestDTO(vacationRequest);

            if (vacationRequest == null)
            {
                return NotFound();
            }

            return vacationRequestDTO;
        }

        // PUT: api/VacationRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacationRequest(int id, VacationRequestDTO vacationRequestDTO)
        {
            VacationRequest vacationrequest = _VacationRequestMapper.ConvertVacationRequestDTOToVacationRequest(vacationRequestDTO);


            if (id != vacationrequest.VacationRequestId)
            {
                return BadRequest();
            }

            _context.Entry(vacationrequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationRequestExists(id))
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



        // POST: api/VacationRequests/1/2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<VacationRequest>> PostVacationRequest(VacationRequestDTO vacationRequestDTO)
        {
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest = _VacationRequestMapper.ConvertVacationRequestDTOToVacationRequest(vacationRequestDTO);
            _context.VacationRequest.Add(vacationRequest);


            EmployeeVacationDTO employeeVacation = (from empvac in _context.EmployeeVacation
                                                    where empvac.EmployeeID == vacationRequest.EmployeeID && empvac.VacationID == vacationRequest.VacationID
                                                    select new EmployeeVacationDTO
                                                    {
                                                        EmployeeID = empvac.EmployeeID,
                                                        VacationID = empvac.VacationID,
                                                        EmployeeUsedVacation = empvac.EmployeeUsedVacation,
                                                        EmployeeBalance = empvac.EmployeeBalance,


                                                    }).FirstOrDefault();


            if (employeeVacation == null)
            {
                return BadRequest();


            }



            employeeVacation.EmployeeID = vacationRequestDTO.EmployeeID;
            employeeVacation.VacationID = vacationRequestDTO.VacationID;
            employeeVacation.EmployeeUsedVacation = employeeVacation.EmployeeUsedVacation + vacationRequest.VacationDuration;
            employeeVacation.EmployeeBalance = employeeVacation.EmployeeBalance - vacationRequest.VacationDuration;
            _context.Entry(employeeVacation).State = EntityState.Modified;
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetVacationRequest", new
            {
                id = vacationRequest.VacationRequestId
            }, vacationRequest);

        }

        // DELETE: api/VacationRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacationRequest(int id)
        {
            var vacationRequest = await _context.VacationRequest.FindAsync(id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            _context.VacationRequest.Remove(vacationRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacationRequestExists(int id)
        {
            return _context.VacationRequest.Any(e => e.VacationRequestId == id);
        }
    }
}
