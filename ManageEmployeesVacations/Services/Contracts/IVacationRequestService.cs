using Models;

namespace Services.Contracts
{
    public interface IVacationRequestService
    {
        EmployeeVacationDTO UpdateEmployeeBalance(VacationRequestDTO vacationRequestDTO, VacationRequest vacationRequest);
        IEnumerable<VacationRequestDTO> GetById(int id);
        IEnumerable<VacationRequestDTO> GetAll();
        void updateVacationRequest(VacationRequestDTO vacationrequest);
        void deleteVacationRequest(int id);
        void PostVacationRequest(VacationRequestDTO vacationRequestDTO);
        void addVacationRequest(VacationRequest vacationrequest);

    }
}
