using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IVacationRequestMapper
    {
        public VacationRequest ConvertVacationRequestDTOToVacationRequest(VacationRequestDTO vacationRequestDTO);
        public VacationRequestDTO ConvertVacationRequestToVacationRequestDTO(VacationRequest VacationRequest);
    }
}
