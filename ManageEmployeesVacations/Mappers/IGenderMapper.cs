using Models;

namespace Mappers
{
    public interface IGenderMapper
    {
        public GenderDTO ConvertGenderToGenderDTO(Gender gender);
        public Gender ConvertGenderDTOToGender(GenderDTO genderDTO);
    }
}
