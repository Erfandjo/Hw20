using App.Infra.Data.Repos.Ef.Hw20.CarModel;

namespace App.Domain.Core.Hw20.CarModel.Data
{
    public interface ICarModelRepository
    {
        public Task<List<CarModelDto>> GetAll(CancellationToken cancellation);
        public Task<CarModel.Entities.CarModel> GetByName(string str, CancellationToken cancellation);
        public Task<Result.Result> Add(CarModel.Entities.CarModel carModel, CancellationToken cancellation);
        public Task<Result.Result> Update(int id , string name , Company.Entities.Company company, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<CarModelDto> GetDtoById(int id, CancellationToken cancellation);
        public Task<CarModel.Entities.CarModel> GetById(int id, CancellationToken cancellation);
    }
}
