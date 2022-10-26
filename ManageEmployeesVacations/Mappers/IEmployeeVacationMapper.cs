using Models;

namespace Mappers
{
    public interface IEmployeeVacationMapper
    {
        public EmployeeVacationDTO ConvertEmployeeVacationToDTO(EmployeeVacation emp);
        public EmployeeVacation ConvertDtoToEmployeeVacation(EmployeeVacationDTO empDTO);
    }
}
