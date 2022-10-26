using Models;

namespace Mappers
{
    public interface IEmployeeVacationDTOPOSTMapper
    {
        public EmployeeVacationDTOPOST ConvertEmployeeDataVacationToDTOPOST(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoPOSTToEmployeeDataVacation(EmployeeVacationDTOPOST empDTO);
    }
}
