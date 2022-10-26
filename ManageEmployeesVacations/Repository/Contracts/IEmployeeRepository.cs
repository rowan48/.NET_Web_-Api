using Models;
namespace Repository.Contracts
{

    public interface IEmployeeRepository
    {
        //Task<IEnumerable<Employee>> GetEmployeesAsync();
        //IEnumerable<Employee> GetEmployees();
        IEnumerable<EmployeeDTO> FindAll();

        EmployeeDTO FindByCondition(int id);

        void Create(Employee entity);
        void Update(Employee entity);
        void Delete(int id);
        public IEnumerable<EmployeeVacationDTO> CheckBalance(int employeeID);


    }


}
