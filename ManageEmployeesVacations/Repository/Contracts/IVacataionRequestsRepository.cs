using Models;

namespace Repository.Contracts
{

    public interface IVacataionRequestsRepository
    {
        IEnumerable<VacationRequestDTO> FindAll();

        IEnumerable<VacationRequestDTO> FindByCondition(int id);

        void Create(VacationRequest entity);
        void Update(VacationRequest entity);
        void Delete(int id);
    }

}
