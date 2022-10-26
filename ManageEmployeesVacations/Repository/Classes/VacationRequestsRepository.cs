using DataCon;
using Models;
using Repository.Contracts;
using Unit.Classes;

namespace Repository.Classes
{
    public class VacationRequestsRepository : GenericRepository, IVacataionRequestsRepository
    {
        protected DataContext _context { get; set; }
        public VacationRequestsRepository(DataContext Context) : base(Context)
        {
            _context = Context;
        }

        void IVacataionRequestsRepository.Create(VacationRequest entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
        }

        void IVacataionRequestsRepository.Delete(int id)
        {
            var vacreq = _context.Employee.Find(id);
            _context.Remove(vacreq);
            // _context.SaveChanges();
        }

        IEnumerable<VacationRequestDTO> IVacataionRequestsRepository.FindAll()
        {
            var vacreqDTO = (
                from vacreq in _context.VacationRequest
                select new VacationRequestDTO
                {
                    VacationID = vacreq.VacationID,
                    VacationDuration = vacreq.VacationDuration,
                    VacationRequestId = vacreq.VacationRequestId,
                    EndVacationDate = vacreq.EndVacationDate,
                    StartVacationDate = vacreq.StartVacationDate,
                    EmployeeID = vacreq.EmployeeID,
                }
                );
            return vacreqDTO;
        }

        IEnumerable<VacationRequestDTO> IVacataionRequestsRepository.FindByCondition(int id)
        {
            var vacreqDTO = (
              from vacreq in _context.VacationRequest
              where vacreq.VacationRequestId == id
              select new VacationRequestDTO
              {
                  VacationID = vacreq.VacationID,
                  VacationDuration = vacreq.VacationDuration,
                  VacationRequestId = vacreq.VacationRequestId,
                  EndVacationDate = vacreq.EndVacationDate,
                  StartVacationDate = vacreq.StartVacationDate,
                  EmployeeID = vacreq.EmployeeID,
              }
              );
            return vacreqDTO;
        }

        void IVacataionRequestsRepository.Update(VacationRequest entity)
        {
            _context.Update(entity);
            //_context.SaveChanges();
        }
    }
}
