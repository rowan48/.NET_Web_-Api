using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class VacationRequestService : IVacationRequestService
    {
        private readonly IEmployeeVacationsRepository _employeeVacationsRepository;
        private readonly IVacataionRequestsRepository _repository;
        private readonly IVacationRequestMapper _VacationRequestMapper;
        private readonly IEmployeeVacationMapper _employeeVacationMapper;
        private readonly IEmployeeVacationService _employeeVacationService;
        private readonly IUnitOfWork _unitOfWork;



        public VacationRequestService(IUnitOfWork unitOfWork, IEmployeeVacationsRepository requestsRepository, IVacataionRequestsRepository repository, IVacationRequestMapper vacationRequestMapper, IEmployeeVacationMapper employeeVacationMapper, IEmployeeVacationService employeeVacationService)
        {
            _employeeVacationsRepository = requestsRepository;
            _repository = repository;
            _VacationRequestMapper = vacationRequestMapper;
            _employeeVacationMapper = employeeVacationMapper;
            _employeeVacationService = employeeVacationService;
            _unitOfWork = unitOfWork;
        }

        public void addVacationRequest(VacationRequest vacationRequest)
        {
            _repository.Create(vacationRequest);
            _unitOfWork.Complete();
        }

        public void deleteVacationRequest(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();


        }

        public IEnumerable<VacationRequestDTO> GetAll()
        {
            return _repository.FindAll();
        }

        public IEnumerable<VacationRequestDTO> GetById(int id)
        {
            return _repository.FindByCondition(id);
        }

        public void updateVacationRequest(VacationRequestDTO vacationrequestdto)
        {
            VacationRequest vacationrequest = _VacationRequestMapper.ConvertVacationRequestDTOToVacationRequest(vacationrequestdto);

            _repository.Update(vacationrequest);
            _unitOfWork.Complete();

        }

        void IVacationRequestService.PostVacationRequest(VacationRequestDTO vacationRequestDTO)
        {
            VacationRequest vacationRequest = _VacationRequestMapper.ConvertVacationRequestDTOToVacationRequest(vacationRequestDTO);
            _repository.Create(vacationRequest);
            var employeeVacation = _employeeVacationsRepository.FindByCondition(vacationRequestDTO.EmployeeID, vacationRequestDTO.VacationID);
            employeeVacation.EmployeeID = vacationRequestDTO.EmployeeID;
            employeeVacation.VacationID = vacationRequestDTO.VacationID;
            employeeVacation.EmployeeUsedVacation = employeeVacation.EmployeeUsedVacation + vacationRequest.VacationDuration;
            employeeVacation.EmployeeBalance = employeeVacation.EmployeeBalance - vacationRequest.VacationDuration;
            EmployeeVacation employeeVacation1 = _employeeVacationMapper.ConvertDtoToEmployeeVacation(employeeVacation);
            _employeeVacationService.update(employeeVacation1);



        }

        EmployeeVacationDTO IVacationRequestService.UpdateEmployeeBalance(VacationRequestDTO vacationRequestDTO, VacationRequest vacationRequest)
        {
            var employeeVacation = _employeeVacationsRepository.FindByCondition(vacationRequestDTO.EmployeeID, vacationRequestDTO.VacationID);
            employeeVacation.EmployeeID = vacationRequestDTO.EmployeeID;
            employeeVacation.VacationID = vacationRequestDTO.VacationID;
            employeeVacation.EmployeeUsedVacation = employeeVacation.EmployeeUsedVacation + vacationRequest.VacationDuration;
            employeeVacation.EmployeeBalance = employeeVacation.EmployeeBalance - vacationRequest.VacationDuration;
            return employeeVacation;
        }
    }
}
