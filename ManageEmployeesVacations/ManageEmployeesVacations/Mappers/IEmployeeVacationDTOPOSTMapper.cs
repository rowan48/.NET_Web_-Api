using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IEmployeeVacationDTOPOSTMapper
    {
        public EmployeeVacationDTOPOST ConvertEmployeeDataVacationToDTOPOST(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoPOSTToEmployeeDataVacation(EmployeeVacationDTOPOST empDTO);
    }
}
