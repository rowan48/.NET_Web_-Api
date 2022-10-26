using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class EmployeeRepository : GenericRepository, IEmployeeRepository
    {
        protected DataContext _context { get; set; }
        public EmployeeRepository(DataContext Context) :
            base(Context)
        {
            _context = Context;
        }


        public IEnumerable<EmployeeDTO> FindAll()
        {
            var empgender =
(from anemp in _context.Employee
 join gend in _context.Gender
 on anemp.GenderId equals gend.GenderId

 select new EmployeeDTO
 {
     EmployeeId = anemp.EmployeeId,
     Email = anemp.Email,
     FullName = anemp.FullName,
     BirthDate = anemp.BirthDate,
     GenderName = gend.GenderType,
     GenderId = gend.GenderId,


 });
            return empgender;
        }

        public EmployeeDTO FindByCondition(int id)
        {
            EmployeeDTO empgender =
(from anemp in _context.Employee
 join gend in _context.Gender
 on anemp.GenderId equals gend.GenderId
 where anemp.EmployeeId == id
 select new EmployeeDTO
 {

     EmployeeId = anemp.EmployeeId,
     Email = anemp.Email,
     FullName = anemp.FullName,
     BirthDate = anemp.BirthDate,
     // GenderName = gend.GenderType,
     GenderId = gend.GenderId,


 }).FirstOrDefault();
            return empgender;
        }

        public void Create(Employee entity)
        {
            _context.Add(entity);
        }

        public void Update(Employee entity)
        {
            _context.Update(entity);
        }

        public void Delete(int id)
        {
            var employee = _context.Employee.Find(id);
            _context.Remove(employee);
        }

        public IEnumerable<EmployeeVacationDTO> CheckBalance(int employeeID)
        {

            var employeeVacations = (from empvac in _context.EmployeeVacation
                                     join vacations in _context.Vacation
                                      on empvac.VacationID equals vacations.VacationId
                                     join emp in _context.Employee on empvac.EmployeeID equals emp.EmployeeId into all
                                     from values in all.DefaultIfEmpty()
                                     where empvac.EmployeeID == employeeID
                                     select new EmployeeVacationDTO
                                     {

                                         EmployeeID = empvac.EmployeeID,
                                         VacationID = empvac.VacationID,
                                         EmployeeBalance = empvac.EmployeeBalance,
                                         EmployeeUsedVacation = empvac.EmployeeUsedVacation,
                                         VacationName = vacations.VacationName,

                                     });
            return employeeVacations;
        }
    }















}
