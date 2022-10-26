using Models;

namespace Mappers
{
    public interface IVacationRequestMapper
    {
        public VacationRequest ConvertVacationRequestDTOToVacationRequest(VacationRequestDTO vacationRequestDTO);
        public VacationRequestDTO ConvertVacationRequestToVacationRequestDTO(VacationRequest VacationRequest);
    }
}
