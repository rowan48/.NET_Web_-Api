using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class VacationRepository : GenericRepository, IVacationRepository
    {
        protected DataContext _context { get; set; }


        public VacationRepository(DataContext Context) : base(Context)
        {
            _context = Context;
        }



        void IVacationRepository.Create(Vacation entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
        }

        void IVacationRepository.Delete(int id)
        {
            var vacation = _context.Vacation.Find(id);

            _context.Remove(vacation);



            // _context.SaveChanges();
        }

        IEnumerable<VacationDTO> IVacationRepository.FindAll()
        {
            var vacations =
(from vac in _context.Vacation

 select new VacationDTO
 {
     VacationId = vac.VacationId,
     VacationName = vac.VacationName,
     Balance = vac.Balance



 });
            return vacations;
        }

        IEnumerable<VacationDTO> IVacationRepository.FindByCondition(int id)
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


            yield return vacation;
        }

        void IVacationRepository.Update(Vacation entity)
        {
            _context.Update(entity);
            // _context.SaveChanges();
        }


        IEnumerable<GetVacationEmployees> IVacationRepository.CheckVacationEmployees(int vacationID)
        {
            var output = (from emp in _context.Employee
                          join empvac in _context.EmployeeVacation
                          on emp.EmployeeId equals empvac.EmployeeID
                          join vac in _context.Vacation
                          on empvac.VacationID equals vac.VacationId
                          into all
                          from values in all.DefaultIfEmpty()
                          where values.VacationId == vacationID

                          select new GetVacationEmployees
                          {

                              name = emp.FullName,
                              balance = empvac.EmployeeBalance,
                              vacno = vacationID == null ? 0 : empvac.VacationID


                          }).FirstOrDefault();
            yield return output;
        }
    }
}
