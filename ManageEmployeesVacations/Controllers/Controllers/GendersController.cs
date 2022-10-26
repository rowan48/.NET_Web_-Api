using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Contracts;
using Unit.Contracts;

namespace Controllers.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {

        private readonly IGenderService _service;
        private readonly IUnitOfWork _unitOfWork;

        public GendersController(IGenderService genderService, IUnitOfWork unitOfWork)
        {
            _service = genderService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Genders
        [HttpGet]
        public IEnumerable<GenderDTO> GetGender()
        {
            // return _unitOfWork.genderService.GetAll();
            return _service.GetAll();

        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public IEnumerable<GenderDTO> GetGender(int id)
        {
            return _service.GetById(id);

        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutGender(GenderDTO genderDTO)
        {
            _service.updateGender(genderDTO);

            //_context.Entry(gender).State = EntityState.Modified;
        }

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostGender(GenderDTO genderDTO)
        {
            _service.addGender(genderDTO);

        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public void DeleteGender(int id)
        {
            _service.deleteGender(id);
        }

    }
}
