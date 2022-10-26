using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IEmployeeMapper
    {
        public EmployeeDTO ConvertEmpToEmpDTO(Employee emp);
        public Employee ConvertEmpDTOToEmp(EmployeeDTO empDTO);
    }
}
