using Models;

namespace Mappers

{
    public class EmployeeMapper : IEmployeeMapper
    {
        Employee IEmployeeMapper.ConvertEmpDTOToEmp(EmployeeDTO empDTO)
        {
            Employee emp = new Employee();

            emp.EmployeeId = empDTO.EmployeeId;
            emp.Email = empDTO.Email;
            emp.FullName = empDTO.FullName;
            emp.GenderId = empDTO.GenderId;
            emp.BirthDate = empDTO.BirthDate;
            return emp;
        }

        EmployeeDTO IEmployeeMapper.ConvertEmpToEmpDTO(Employee emp)
        {
            EmployeeDTO empDTO = new EmployeeDTO();

            empDTO.EmployeeId = emp.EmployeeId;
            empDTO.Email = emp.Email;

            empDTO.FullName = emp.FullName;
            empDTO.GenderId = emp.GenderId;
            empDTO.BirthDate = emp.BirthDate;
            if (emp.Gender != null)
            {
                empDTO.GenderName = emp.Gender.GenderType;
            }

            return empDTO;

        }
    }
}
