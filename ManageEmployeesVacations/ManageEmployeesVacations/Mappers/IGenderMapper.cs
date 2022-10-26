using ManageEmployeesVacations.DTO;
using ManageEmployeesVacations.Models;

namespace ManageEmployeesVacations.Mappers
{
    public interface IGenderMapper
    {
        public GenderDTO ConvertGenderToGenderDTO(Gender gender);
        public Gender ConvertGenderDTOToGender(GenderDTO genderDTO);
    }
}
