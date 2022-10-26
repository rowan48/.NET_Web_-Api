using Models;

namespace Services.Contracts
{
    public interface IEmployeeVacationService
    {
        IEnumerable<EmployeeVacationDTO> GetById(int id);
        IEnumerable<EmployeeVacationDTO> GetAll();
        void update(EmployeeVacation employeevacation);
        void delete(int id);
        void add(EmployeeVacationDTOPOST employeevacation);

        //EmployeeDTO CheckEmployeeVacation(EmployeeDTO employee, EmployeeDataVcationsDTO EmployeeVacation);
        //EmployeeVacationDTO CheckVacations(int id1, int id2, EmployeeDataVcationsDTO EmployeeVacation);
        void PutEmployeeVacation(int id, EmployeeDataVcationsDTO EmployeeVacation);

    }
}
