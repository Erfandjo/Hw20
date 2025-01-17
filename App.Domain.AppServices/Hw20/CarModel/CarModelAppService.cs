using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Service;
using App.Domain.Core.Hw20.Result;

namespace App.Domain.AppServices.Hw20.CarModel
{
    public class CarModelAppService : ICarModelAppService
    {
        private readonly ICarModelService _carModelService;

        public CarModelAppService(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        public Result Add(Core.Hw20.CarModel.Entities.CarModel carModel)
        {
           return _carModelService.Add(carModel);
        }

        public Result Delete(int id)
        {
            return _carModelService.Delete(id);
        }

        public List<Core.Hw20.CarModel.Entities.CarModel> GetAll()
        {
           return _carModelService.GetAll();
        }

        public Core.Hw20.CarModel.Entities.CarModel GetById(int id)
        {
            return _carModelService.GetById(id);
        }

        public Core.Hw20.CarModel.Entities.CarModel GetByName(string str)
        {
           return _carModelService.GetByName(str);
        }

        public Result Update(int id, string name, Core.Hw20.Company.Entities.Company company)
        {
            return _carModelService.Update(id, name, company);
        }
    }
}
