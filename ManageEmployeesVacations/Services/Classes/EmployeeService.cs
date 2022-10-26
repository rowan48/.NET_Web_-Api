using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IEmployeeMapper _employeeMapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacationRepository _vacationRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository repository, IEmployeeMapper employeeMapper, IVacationRepository vacationRepository)
        {
            _repository = repository;
            _employeeMapper = employeeMapper;
            _unitOfWork = unitOfWork;
            _vacationRepository = vacationRepository;
        }

        public void addEmployee(Employee employee)
        {
            _repository.Create(employee);
            // _unitOfWork._employeeRepository.Create(employee);
            _unitOfWork.Complete();

            // _unitOfWork.employeeRepository.Create(employee);
            //_repository.Create(employee);

        }

        public int deleteEmployee(int id)
        {
            _repository.Delete(id);
            //_unitOfWork._employeeRepository.Delete(id);
            return _unitOfWork.Complete();

            //  _unitOfWork.employeeRepository.Delete(id);
            //_repository.Delete(id);
        }

        IEnumerable<EmployeeVacationDTO> IEmployeeService.CheckBalance(int id)
        {
            return _repository.CheckBalance(id);
            // return _unitOfWork._employeeRepository.CheckBalance(id);
            //return _unitOfWork.employeeRepository.CheckBalance(id);
            // return _repository.CheckBalance(id);
        }

        EmployeeDTO IEmployeeService.GetById(int id)
        {
            // return _unitOfWork.employeeRepository.FindByCondition(id);
            return _repository.FindByCondition(id);
        }

        IEnumerable<EmployeeDTO> IEmployeeService.GetEmployees()
        {
            // return _unitOfWork._employeeRepository.FindAll();
            // return _unitOfWork.employeeRepository.FindAll();
            var emp = _repository.FindAll();
            return emp;
        }

        int IEmployeeService.postEmployee(EmployeeDTO fetchedEmployee)
        {
            Employee fetchedEmp = _employeeMapper.ConvertEmpDTOToEmp(fetchedEmployee);
            var vacations = _vacationRepository.FindAll();

            // var vacations = _vacationservice.Getall();

            List<EmployeeVacation> employeeVacations = new List<EmployeeVacation>();

            foreach (VacationDTO vacation in vacations)
            {
                EmployeeVacation employeeVacation = new EmployeeVacation()
                {
                    VacationID = vacation.VacationId,
                    EmployeeUsedVacation = 0,
                    EmployeeBalance = vacation.Balance

                };
                employeeVacations.Add(employeeVacation);
                fetchedEmp.EmployeeVacations = employeeVacations;
            }
            //_unitOfWork.employeeRepository.Create(fetchedEmp);
            _repository.Create(fetchedEmp);

            // _unitOfWork._employeeRepository.Create(fetchedEmp);
            return _unitOfWork.Complete();

        }

        int IEmployeeService.updateEmployee(EmployeeDTO employee)
        {
            Employee emp = _employeeMapper.ConvertEmpDTOToEmp(employee);
            //_unitOfWork.employeeRepository.Update(emp);
            //_unitOfWork._employeeRepository.Update(emp);
            _repository.Update(emp);
            return _unitOfWork.Complete();
            //_repository.Update(emp);
        }

        Employee IEmployeeService.UpdateVacations(Employee fetchedEmp, IEnumerable<VacationDTO> vacations)
        {
            List<EmployeeVacation> employeeVacations = new List<EmployeeVacation>();

            foreach (VacationDTO vacation in vacations)
            {
                EmployeeVacation employeeVacation = new EmployeeVacation()
                {
                    VacationID = vacation.VacationId,
                    EmployeeUsedVacation = 0,
                    EmployeeBalance = vacation.Balance

                };
                employeeVacations.Add(employeeVacation);
                fetchedEmp.EmployeeVacations = employeeVacations;
            }
            return fetchedEmp;
        }
    }
}
