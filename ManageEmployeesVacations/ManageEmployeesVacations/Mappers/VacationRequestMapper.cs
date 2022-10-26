using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public class VacationRequestMapper : IVacationRequestMapper
    {




        VacationRequest IVacationRequestMapper.ConvertVacationRequestDTOToVacationRequest(VacationRequestDTO vacationRequestDTO)
        {
            VacationRequest vacationRequest = new VacationRequest();
            vacationRequest.VacationRequestId = vacationRequestDTO.VacationRequestId;
            vacationRequest.EmployeeID = vacationRequestDTO.EmployeeID;
            vacationRequest.VacationID = vacationRequestDTO.VacationID;
            vacationRequest.StartVacationDate = vacationRequestDTO.StartVacationDate;
            vacationRequest.EndVacationDate = vacationRequestDTO.EndVacationDate;
            vacationRequest.VacationDuration = vacationRequestDTO.VacationDuration;

            return vacationRequest;
        }



        VacationRequestDTO IVacationRequestMapper.ConvertVacationRequestToVacationRequestDTO(VacationRequest VacationRequest)
        {
            VacationRequestDTO VacationRequestDTO = new VacationRequestDTO();
            VacationRequestDTO.VacationRequestId = VacationRequest.VacationRequestId;
            VacationRequestDTO.EmployeeID = VacationRequest.EmployeeID;
            VacationRequestDTO.VacationID = VacationRequest.VacationID;
            VacationRequestDTO.StartVacationDate = VacationRequest.StartVacationDate;
            VacationRequestDTO.EndVacationDate = VacationRequest.EndVacationDate;
            VacationRequestDTO.VacationDuration = VacationRequest.VacationDuration;

            return VacationRequestDTO;
        }
    }
}
