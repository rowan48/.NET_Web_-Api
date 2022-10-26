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
    public class GendersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IGenderMapper _genderMapper;

        public GendersController(DataContext context, IGenderMapper genderMapper)
        {
            _context = context;
            _genderMapper = genderMapper;
        }

        // GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderDTO>>> GetGender()
        {
            List<Gender> gender = await _context.Gender.ToListAsync();
            List<GenderDTO> genderDTO = new List<GenderDTO>();
            foreach (Gender agender in gender)
            {
                genderDTO.Add(_genderMapper.ConvertGenderToGenderDTO(agender));

            }

            return genderDTO;
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderDTO>> GetGender(int id)
        {
            var gender = await _context.Gender.FindAsync(id);

            if (gender == null)
            {
                return NotFound();
            }

            return _genderMapper.ConvertGenderToGenderDTO(gender);
        }

        // PUT: api/Genders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGender(int id, GenderDTO genderDTO)
        {
            Gender gender = _genderMapper.ConvertGenderDTOToGender(genderDTO);




            if (id != gender.GenderId)
            {
                return BadRequest();
            }

            _context.Entry(gender).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(id))
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

        // POST: api/Genders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenderDTO>> PostGender(GenderDTO genderDTO)
        {


            Gender fetchedGender = _genderMapper.ConvertGenderDTOToGender(genderDTO);
            _context.Gender.Add(fetchedGender);
            await _context.SaveChangesAsync();

            GenderDTO genderdto = _genderMapper.ConvertGenderToGenderDTO(fetchedGender);

            return CreatedAtAction("GetGender", new { id = genderdto.GenderId }, genderdto);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var gender = await _context.Gender.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }

            _context.Gender.Remove(gender);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenderExists(int id)
        {
            return _context.Gender.Any(e => e.GenderId == id);
        }
    }
}
