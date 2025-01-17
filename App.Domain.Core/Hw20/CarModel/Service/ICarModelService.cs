namespace App.Domain.Core.Hw20.CarModel.Service
{
    public interface ICarModelService
    {
        public List<CarModel.Entities.CarModel> GetAll();
        public CarModel.Entities.CarModel GetByName(string str);
        public Result.Result Add(CarModel.Entities.CarModel carModel);
        public Result.Result Update(int id, string name, Company.Entities.Company company);
        public Result.Result Delete(int id);
        public CarModel.Entities.CarModel GetById(int id);
    }
}
