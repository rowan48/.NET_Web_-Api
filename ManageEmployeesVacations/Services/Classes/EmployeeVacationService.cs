using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class EmployeeVacationService : IEmployeeVacationService
    {
        public readonly IEmployeeVacationsRepository _repository;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeMapper _employeeMapper;
        private readonly IEmployeeVacationMapper _mapper;
        private readonly IEmployeeVacationDTOPOSTMapper _employeeVacationDTOPOSTMapper;
        private readonly IUnitOfWork _unitOfWork;





        public EmployeeVacationService(IUnitOfWork unitOfWork, IEmployeeVacationsRepository employeeVacationsRepository, IEmployeeService employeeService, IEmployeeMapper employeeMapper, IEmployeeVacationMapper mapper, IEmployeeVacationDTOPOSTMapper employeeVacationDTOPOSTMapper)
        {
            _repository = employeeVacationsRepository;
            _employeeService = employeeService;
            _employeeMapper = employeeMapper;
            _mapper = mapper;
            _employeeVacationDTOPOSTMapper = employeeVacationDTOPOSTMapper;
            _unitOfWork = unitOfWork;
        }

        //public EmployeeDTO CheckEmployeeVacation(EmployeeDTO employee, EmployeeDataVcationsDTO EmployeeVacation)
        //{
        //    if (EmployeeVacation.FullName != null)
        //    {
        //        employee.FullName = EmployeeVacation.FullName;

        //    }
        //    if (EmployeeVacation.BirthDate != null)
        //    {
        //        employee.BirthDate = (DateTime)EmployeeVacation.BirthDate;

        //    }
        //    if (EmployeeVacation.GenderId != null)
        //    {
        //        employee.GenderId = (int)EmployeeVacation.GenderId;

        //    }


        //    if (employee.Email != null && EmployeeVacation.Email != null)
        //    {
        //        employee.Email = EmployeeVacation.Email;

        //    }
        //    return employee;
        //}

        public void PutEmployeeVacation(int id, EmployeeDataVcationsDTO EmployeeVacation)
        {
            var employee = _employeeService.GetById(id);
            if (EmployeeVacation.FullName != null)
            {
                employee.FullName = EmployeeVacation.FullName;

            }
            if (EmployeeVacation.BirthDate != null)
            {
                employee.BirthDate = (DateTime)EmployeeVacation.BirthDate;

            }
            if (EmployeeVacation.GenderId != null)
            {
                employee.GenderId = (int)EmployeeVacation.GenderId;

            }


            if (employee.Email != null && EmployeeVacation.Email != null)
            {
                employee.Email = EmployeeVacation.Email;

            }
            var empvac = _repository.FindByCondition(id, EmployeeVacation.VacationID);
            empvac.EmployeeBalance = EmployeeVacation.EmployeeBalance;
            Employee emp = _employeeMapper.ConvertEmpDTOToEmp(employee);

            _employeeService.updateEmployee(employee);
            EmployeeVacation employeeVacation = _mapper.ConvertDtoToEmployeeVacation(empvac);
            _repository.Update(employeeVacation);


        }

        void IEmployeeVacationService.add(EmployeeVacationDTOPOST employeevacation)
        {
            EmployeeVacation FetchedEmpVacation = _employeeVacationDTOPOSTMapper.ConvertDtoPOSTToEmployeeDataVacation(employeevacation);

            _repository.Create(FetchedEmpVacation);

        }

        //EmployeeVacationDTO IEmployeeVacationService.CheckVacations(int id1, int id2, EmployeeDataVcationsDTO EmployeeVacation)
        //{

        //    var empvac = _repository.FindByCondition(id1, id2);
        //    empvac.EmployeeBalance = EmployeeVacation.EmployeeBalance;
        //    return empvac;
        //}

        void IEmployeeVacationService.delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();

        }

        IEnumerable<EmployeeVacationDTO> IEmployeeVacationService.GetAll()
        {
            return _repository.FindAll();
        }

        IEnumerable<EmployeeVacationDTO> IEmployeeVacationService.GetById(int id)
        {
            return _repository.FindByCondition(id);
        }

        void IEmployeeVacationService.update(EmployeeVacation employeevacation)
        {
            _repository.Update(employeevacation);
            _unitOfWork.Complete();
        }
    }
}
