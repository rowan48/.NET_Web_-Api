using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IVacationMapper
    {
        public VacationDTO ConvertVacationToVacationDTO(Vacation vacation);
        public Vacation ConvertVacationDTOToVacation(VacationDTO vacationDTO);
    }
}
