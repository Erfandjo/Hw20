using App.Domain.Core.Hw20.CarModel.Data;
using App.Domain.Core.Hw20.CarModel.Service;
using App.Domain.Core.Hw20.Result;
using App.Infra.Data.Repos.Ef.Hw20.CarModel;

namespace App.Domain.Services.Hw20.CarModel
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _carModelRepository;

        public CarModelService(ICarModelRepository carModelRepository)
        {
            _carModelRepository = carModelRepository;
        }

        public async Task<Result> Add(Core.Hw20.CarModel.Entities.CarModel carModel , CancellationToken cancellation)
        {
            return await _carModelRepository.Add(carModel, cancellation);
        }

        public async Task<Result> Delete(int id , CancellationToken cancellationToken)
        {
            return await _carModelRepository.Delete(id , cancellationToken);
        }

        public async Task<List<CarModelDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _carModelRepository.GetAll(cancellationToken);
        }

        public async Task<CarModelDto> GetDtoById(int id , CancellationToken cancellation)
        {
            return await _carModelRepository.GetDtoById(id , cancellation);
        }

        public async Task<Core.Hw20.CarModel.Entities.CarModel> GetByName(string str , CancellationToken cancellationToken)
        {
           return await _carModelRepository.GetByName(str , cancellationToken);
        }

        public async Task<Result> Update(int id, string name, Core.Hw20.Company.Entities.Company company , CancellationToken cancellation)
        {
           return await _carModelRepository.Update(id, name, company , cancellation);
        }

        public async Task<Core.Hw20.CarModel.Entities.CarModel> GetById(int id , CancellationToken cancellation)
        {
            return await _carModelRepository.GetById(id , cancellation);
        }
    }
}
