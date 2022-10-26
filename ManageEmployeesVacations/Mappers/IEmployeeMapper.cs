using Models;

namespace Mappers
{
    public interface IEmployeeMapper
    {
        public EmployeeDTO ConvertEmpToEmpDTO(Employee emp);
        public Employee ConvertEmpDTOToEmp(EmployeeDTO empDTO);
    }
}
