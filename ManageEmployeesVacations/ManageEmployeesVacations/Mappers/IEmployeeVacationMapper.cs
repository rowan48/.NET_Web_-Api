using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IEmployeeVacationMapper
    {
        public EmployeeVacationDTO ConvertEmployeeVacationToDTO(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoToEmployeeVacation(EmployeeVacationDTO empDTO);
    }
}
