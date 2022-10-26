using Models;

namespace Mappers
{
    public interface IEmployeeDataVacationsMapper
    {
        public EmployeeDataVcationsDTO ConvertEmployeeDataVacationToDTO(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoToEmployeeDataVacation(EmployeeDataVcationsDTO empDTO);
    }
}
