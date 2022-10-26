using Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IVacationMapper _VacationMapper;
        private readonly IVacationService _service;


        public VacationsController(IVacationMapper vacationMapper, IVacationService vacationService)
        {

            _VacationMapper = vacationMapper;
            _service = vacationService;
        }

        // GET: api/Vacations
        [HttpGet]
        public IEnumerable<VacationDTO> GetVacation()
        {
            return _service.Getall();
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public IEnumerable<VacationDTO> GetVacation(int id)
        {
            return _service.GetById(id);
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutVacation(int id, VacationDTO vacationDTO)
        {

            _service.updateVacation(vacationDTO);


        }

        // POST: api/Vacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostVacation(VacationDTO vacationDTO)
        {

            _service.addVacation(vacationDTO);


        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public void DeleteVacation(int id)
        {
            _service.deleteVacation(id);
        }
        [HttpGet("{vacationID}/CheckVacationEmployees")]
        public IEnumerable<GetVacationEmployees> CheckVacationEmployees(int vacationID)
        {
            return _service.CheckVacationEmployees(vacationID);
        }


        private bool VacationExists(int id)
        {
            return false;
        }
    }
}
