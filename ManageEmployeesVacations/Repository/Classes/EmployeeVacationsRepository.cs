using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class EmployeeVacationsRepository : GenericRepository, IEmployeeVacationsRepository
    {
        protected DataContext _context { get; set; }


        public EmployeeVacationsRepository(DataContext Context) : base(Context)
        {
            _context = Context;
        }

        IEnumerable<EmployeeVacationDTO> IEmployeeVacationsRepository.FindAll()
        {
            var empvacations =
(from vac in _context.EmployeeVacation

 select new EmployeeVacationDTO
 {
     VacationID = vac.VacationID,
     EmployeeBalance = vac.EmployeeBalance,
     EmployeeID = vac.EmployeeID,
     EmployeeUsedVacation = vac.EmployeeUsedVacation,



 });
            return empvacations;
        }

        IEnumerable<EmployeeVacationDTO> IEmployeeVacationsRepository.FindByCondition(int id)
        {
            EmployeeVacationDTO empvacations =
                          (from vacations in _context.EmployeeVacation
                           where vacations.EmployeeID == id
                           select new EmployeeVacationDTO
                           {
                               EmployeeID = vacations.EmployeeID,
                               VacationID = vacations.VacationID,
                               EmployeeBalance = vacations.EmployeeBalance,
                               EmployeeUsedVacation = vacations.EmployeeUsedVacation,


                           }).FirstOrDefault();


            yield return empvacations;
        }

        void IEmployeeVacationsRepository.Create(EmployeeVacation entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

        }

        void IEmployeeVacationsRepository.Update(EmployeeVacation entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;



        }

        void IEmployeeVacationsRepository.Delete(int id)
        {
            var employeevacation = _context.EmployeeVacation.Find(id);
            _context.Remove(employeevacation);
            //_context.SaveChanges();
        }

        EmployeeVacationDTO IEmployeeVacationsRepository.FindByCondition(int id1, int id2)
        {
            EmployeeVacationDTO empvacations =
                        (from vacations in _context.EmployeeVacation
                         where vacations.EmployeeID == id1 && vacations.VacationID == id2
                         select new EmployeeVacationDTO
                         {
                             EmployeeID = vacations.EmployeeID,
                             VacationID = vacations.VacationID,
                             EmployeeBalance = vacations.EmployeeBalance,
                             EmployeeUsedVacation = vacations.EmployeeUsedVacation,


                         }).FirstOrDefault();
            return empvacations;
        }
    }
}
