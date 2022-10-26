using Mappers;
using Models;
using Repository.Contracts;
using Services.Contracts;
using Unit.Contracts;

namespace Services.Classes
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;
        private readonly IGenderMapper _genderMapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenderService(IUnitOfWork unitOfWork, IGenderRepository repository, IGenderMapper genderMapper)
        {
            _repository = repository;
            _genderMapper = genderMapper;
            _unitOfWork = unitOfWork;
        }

        void IGenderService.addGender(GenderDTO gender)
        {
            Gender fetchedGender = _genderMapper.ConvertGenderDTOToGender(gender);

            _repository.Create(fetchedGender);
            _unitOfWork.Complete();

        }

        void IGenderService.deleteGender(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Complete();

        }

        IEnumerable<GenderDTO> IGenderService.GetAll()
        {
            return _repository.FindAll();
        }

        IEnumerable<GenderDTO> IGenderService.GetById(int id)
        {
            return _repository.FindByCondition(id);
        }

        void IGenderService.updateGender(GenderDTO genderdto)
        {
            Gender gender = _genderMapper.ConvertGenderDTOToGender(genderdto);

            _repository.Update(gender);
            _unitOfWork.Complete();

        }
    }
}
