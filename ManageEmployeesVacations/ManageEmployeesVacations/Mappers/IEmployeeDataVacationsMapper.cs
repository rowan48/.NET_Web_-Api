using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IEmployeeDataVacationsMapper
    {
        public EmployeeDataVcationsDTO ConvertEmployeeDataVacationToDTO(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoToEmployeeDataVacation(EmployeeDataVcationsDTO empDTO);
    }
}
