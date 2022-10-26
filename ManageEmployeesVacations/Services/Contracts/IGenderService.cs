using Models;

namespace Services.Contracts
{
    public interface IGenderService
    {
        IEnumerable<GenderDTO> GetById(int id);
        IEnumerable<GenderDTO> GetAll();
        void updateGender(GenderDTO gender);
        void deleteGender(int id);
        void addGender(GenderDTO gender);
    }
}
