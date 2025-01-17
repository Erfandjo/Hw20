using App.Domain.Core.Hw20.CarModel.Data;
using App.Domain.Core.Hw20.CarModel.Service;
using App.Domain.Core.Hw20.Result;

namespace App.Domain.Services.Hw20.CarModel
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public Result Add(Core.Hw20.CarModel.Entities.CarModel carModel)
        {
            return _carModelRepository.Add(carModel);
        }

        public Result Delete(int id)
        {
            return _carModelRepository.Delete(id);
        }

        public List<Core.Hw20.CarModel.Entities.CarModel> GetAll()
        {
            return _carModelRepository.GetAll();
        }

        public Core.Hw20.CarModel.Entities.CarModel GetById(int id)
        {
            return _carModelRepository.GetById(id);
        }

        public Core.Hw20.CarModel.Entities.CarModel GetByName(string str)
        {
           return _carModelRepository.GetByName(str);
        }

        public Result Update(int id, string name, Core.Hw20.Company.Entities.Company company)
        {
           return _carModelRepository.Update(id, name, company);
        }
    }
}
