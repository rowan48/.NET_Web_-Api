using Models;

namespace Mappers
{
    public class GenderMapper : IGenderMapper
    {


        Gender IGenderMapper.ConvertGenderDTOToGender(GenderDTO genderDTO)
        {
            Gender gender = new Gender();
            gender.GenderId = genderDTO.GenderId;
            gender.GenderType = genderDTO.GenderType;
            return gender;
        }

        GenderDTO IGenderMapper.ConvertGenderToGenderDTO(Gender gender)
        {
            GenderDTO genderDTO = new GenderDTO();
            genderDTO.GenderId = gender.GenderId;
            genderDTO.GenderType = gender.GenderType;
            return genderDTO;
        }
    }
}
