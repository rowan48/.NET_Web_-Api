using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public class EmployeeVacationDTOPOSTMapper : IEmployeeVacationDTOPOSTMapper
    {
        EmployeeVacation IEmployeeVacationDTOPOSTMapper.ConvertDtoPOSTToEmployeeDataVacation(EmployeeVacationDTOPOST employeeVacatioDTO)
        {
            EmployeeVacation employeeVacation = new EmployeeVacation()
            {
                EmployeeID = employeeVacatioDTO.EmployeeID,
                VacationID = employeeVacatioDTO.VacationID,
                EmployeeBalance = employeeVacatioDTO.EmployeeBalance,
            };
            return employeeVacation;
        }



        EmployeeVacationDTOPOST IEmployeeVacationDTOPOSTMapper.ConvertEmployeeDataVacationToDTOPOST(EmployeeVacation employeeVacation)
        {
            EmployeeVacationDTOPOST employeeVacationDto = new EmployeeVacationDTOPOST()
            {
                EmployeeID = employeeVacation.EmployeeID,
                VacationID = employeeVacation.VacationID,
                EmployeeBalance = employeeVacation.EmployeeBalance,

            };
            return employeeVacationDto;
        }
    }
}
