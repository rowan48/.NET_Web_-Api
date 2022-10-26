using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public class EmployeeDataVacationsMapper : IEmployeeDataVacationsMapper
    {
        EmployeeVacation IEmployeeDataVacationsMapper.ConvertDtoToEmployeeDataVacation(EmployeeDataVcationsDTO EmployeeDataVcationsDTO)
        {
            EmployeeVacation employeeVacation = new EmployeeVacation()
            {
                //EmployeeID = EmployeeDataVcationsDTO.EmployeeId,
                //VacationID = EmployeeDataVcationsDTO.EmployeeVacations,

                //EmployeeBalance = EmployeeDataVcationsDTO.EmployeeBalance,
                //EmployeeUsedVacation = EmployeeDataVcationsDTO.EmployeeUsedVacation
            };
            return employeeVacation;
        }

        EmployeeDataVcationsDTO IEmployeeDataVacationsMapper.ConvertEmployeeDataVacationToDTO(EmployeeVacation emp)
        {
            throw new NotImplementedException();
        }
    }
}
