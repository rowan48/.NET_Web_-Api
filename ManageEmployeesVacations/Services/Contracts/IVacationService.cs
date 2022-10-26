using Models;

namespace Services.Contracts
{
    public interface IVacationService
    {
        IEnumerable<VacationDTO> Getall();
        IEnumerable<VacationDTO> GetById(int id);
        void updateVacation(VacationDTO vacation);
        void deleteVacation(int id);
        void addVacation(VacationDTO vacation);
        IEnumerable<GetVacationEmployees> CheckVacationEmployees(int vacationID);
    }
}
