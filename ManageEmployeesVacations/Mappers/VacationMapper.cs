using Models;

namespace Mappers
{
    public class VacationMapper : IVacationMapper
    {
        Vacation IVacationMapper.ConvertVacationDTOToVacation(VacationDTO vacationDTO)
        {
            Vacation vacation = new Vacation();
            vacation.VacationId = vacationDTO.VacationId;
            vacation.VacationName = vacationDTO.VacationName;
            vacation.Balance = vacationDTO.Balance;
            // vacation.EmployeeVacations = vacationDTO.EmployeeVacations;
            return vacation;
        }

        VacationDTO IVacationMapper.ConvertVacationToVacationDTO(Vacation vacation)
        {
            VacationDTO vacationDTO = new VacationDTO();
            vacationDTO.VacationId = vacation.VacationId;
            vacationDTO.VacationName = vacation.VacationName;
            vacationDTO.Balance = vacation.Balance;
            // vacationDTO.EmployeeVacations = vacation.EmployeeVacations;
            return vacationDTO;

        }
    }
}
