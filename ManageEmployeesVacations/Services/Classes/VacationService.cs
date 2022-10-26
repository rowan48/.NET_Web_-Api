using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class VacationService : IVacationService
    {
        private IVacationRepository _repository;
        private readonly IVacationMapper _VacationMapper;
        private readonly IUnitOfWork _unitOfWork;

        public VacationService(IUnitOfWork unitOfWork, IVacationRepository repository, IVacationMapper vacationMapper)
        {
            _repository = repository;
            _VacationMapper = vacationMapper;
            _unitOfWork = unitOfWork;
        }

        void IVacationService.addVacation(VacationDTO vacationDTO)
        {
            Vacation fetchedVac = _VacationMapper.ConvertVacationDTOToVacation(vacationDTO);

            _repository.Create(fetchedVac);
            _unitOfWork.Complete();
        }

        IEnumerable<GetVacationEmployees> IVacationService.CheckVacationEmployees(int vacationID)
        {
            return _repository.CheckVacationEmployees(vacationID);
        }

        void IVacationService.deleteVacation(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();

        }

        IEnumerable<VacationDTO> IVacationService.Getall()
        {
            return _repository.FindAll();
        }

        IEnumerable<VacationDTO> IVacationService.GetById(int id)
        {
            return _repository.FindByCondition(id);
        }

        void IVacationService.updateVacation(VacationDTO vacationDTO)
        {
            Vacation vacation = _VacationMapper.ConvertVacationDTOToVacation(vacationDTO);

            _repository.Update(vacation);
            _unitOfWork.Complete();

        }
    }
}
