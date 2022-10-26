using Models;

namespace Repository.Contracts
{
    public interface IEmployeeVacationsRepository
    {
        IEnumerable<EmployeeVacationDTO> FindAll();

        IEnumerable<EmployeeVacationDTO> FindByCondition(int id);

        void Create(EmployeeVacation entity);
        void Update(EmployeeVacation entity);
        void Delete(int id);
        EmployeeVacationDTO FindByCondition(int id1, int id2);


    }
}
