using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Mappers;
using ManageEmployeesVacations.Models;

namespace ManageEmployeeVacationsVacations.Mappers

{
    public class EmployeeVacationMapper : IEmployeeVacationMapper
    {
        EmployeeVacation IEmployeeVacationMapper.ConvertDtoToEmployeeVacation(EmployeeVacationDTO employeeVacatioDTO)
        {
            EmployeeVacation employeeVacation = new EmployeeVacation()
            {
                EmployeeID = employeeVacatioDTO.EmployeeID,
                VacationID = employeeVacatioDTO.VacationID,
                EmployeeBalance = employeeVacatioDTO.EmployeeBalance,
                EmployeeUsedVacation = employeeVacatioDTO.EmployeeUsedVacation
            };
            return employeeVacation;
        }

        EmployeeVacationDTO IEmployeeVacationMapper.ConvertEmployeeVacationToDTO(EmployeeVacation employeeVacation)
        {
            EmployeeVacationDTO employeeVacationDto = new EmployeeVacationDTO()
            {
                EmployeeID = employeeVacation.EmployeeID,
                VacationID = employeeVacation.VacationID,
                EmployeeBalance = employeeVacation.EmployeeBalance,
                EmployeeUsedVacation = employeeVacation.EmployeeUsedVacation,
                VacationName = employeeVacation.Vacation.VacationName
                // VactionType = employeeVacation.Vacation != null ? employeeVacation.Vacation.VacationName : String.Empty
            };
            return employeeVacationDto;
        }
    }
}
