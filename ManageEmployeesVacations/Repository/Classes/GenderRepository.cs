using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class GenderRepository : GenericRepository, IGenderRepository
    {
        protected DataContext _context { get; set; }
        public GenderRepository(DataContext Context) : base(Context)
        {
            _context = Context;
        }


        void IGenderRepository.Create(Gender entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
        }

        void IGenderRepository.Delete(int id)
        {
            var gender = _context.Gender.Find(id);

            _context.Remove(gender);




            //  _context.SaveChanges();
        }

        IEnumerable<GenderDTO> IGenderRepository.FindAll()
        {
            GenderDTO gender = (
                from gend in _context.Gender
                select new GenderDTO
                {
                    GenderId = gend.GenderId,
                    GenderType = gend.GenderType,
                }
                ).FirstOrDefault();
            yield return gender;
        }

        IEnumerable<GenderDTO> IGenderRepository.FindByCondition(int id)
        {
            GenderDTO gender = (
               from gend in _context.Gender
               where gend.GenderId == id
               select new GenderDTO
               {
                   GenderId = gend.GenderId,
                   GenderType = gend.GenderType,
               }
               ).FirstOrDefault();
            yield return gender;

        }

        void IGenderRepository.Update(Gender entity)
        {
            _context.Update(entity);
            //  _context.SaveChanges();
        }
    }
}
