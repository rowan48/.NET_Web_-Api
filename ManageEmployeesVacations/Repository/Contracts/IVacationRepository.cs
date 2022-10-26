using Models;
namespace Repository.Contracts
{
    public interface IVacationRepository
    {
        IEnumerable<VacationDTO> FindAll();

        IEnumerable<VacationDTO> FindByCondition(int id);

        void Create(Vacation entity);
        void Update(Vacation entity);
        void Delete(int id);
        IEnumerable<GetVacationEmployees> CheckVacationEmployees(int vacationID);
    }
}
