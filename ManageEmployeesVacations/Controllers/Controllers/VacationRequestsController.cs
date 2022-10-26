using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VacationRequestsController : ControllerBase
    {

        private readonly IVacationRequestService _service;

        public VacationRequestsController(IVacationRequestService vacationRequestService)
        {

            _service = vacationRequestService;

        }

        // GET: api/VacationRequests
        [HttpGet]
        public IEnumerable<VacationRequestDTO> GetVacationRequest()
        {
            return _service.GetAll();
        }

        // GET: api/VacationRequests/5
        [HttpGet("{id}")]
        public IEnumerable<VacationRequestDTO> GetVacationRequest(int id)
        {
            return _service.GetById(id);

        }

        // PUT: api/VacationRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutVacationRequest(VacationRequestDTO vacationRequestDTO)
        {
            _service.updateVacationRequest(vacationRequestDTO);


        }



        // POST: api/VacationRequests/1/2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public void PostVacationRequest(VacationRequestDTO vacationRequestDTO)
        {
            _service.PostVacationRequest(vacationRequestDTO);

        }

        // DELETE: api/VacationRequests/5
        [HttpDelete("{id}")]
        public void DeleteVacationRequest(int id)
        {
            _service.deleteVacationRequest(id);

        }

        private bool VacationRequestExists(int id)
        {
            return false;
        }
    }
}
