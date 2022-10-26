using Models;

namespace Repository.Contracts
{
    public interface IGenderRepository
    {
        IEnumerable<GenderDTO> FindAll();

        IEnumerable<GenderDTO> FindByCondition(int id);

        void Create(Gender entity);
        void Update(Gender entity);
        void Delete(int id);
    }
}
