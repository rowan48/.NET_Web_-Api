using Models;

namespace Mappers
{
    public interface IVacationMapper
    {
        public VacationDTO ConvertVacationToVacationDTO(Vacation vacation);
        public Vacation ConvertVacationDTOToVacation(VacationDTO vacationDTO);
    }
}
