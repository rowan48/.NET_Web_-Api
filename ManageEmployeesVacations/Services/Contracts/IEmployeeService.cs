using Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {

        Employee UpdateVacations(Employee fetchedEmp, IEnumerable<VacationDTO> vacations);
        EmployeeDTO GetById(int id);
        IEnumerable<EmployeeDTO> GetEmployees();
        int updateEmployee(EmployeeDTO employee);
        int deleteEmployee(int id);
        void addEmployee(Employee employee);
        IEnumerable<EmployeeVacationDTO> CheckBalance(int id);
        int postEmployee(EmployeeDTO fetchedEmp);
    }
}
