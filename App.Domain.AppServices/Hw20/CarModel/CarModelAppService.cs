using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Service;
using App.Domain.Core.Hw20.Company.AppService;
using App.Domain.Core.Hw20.Result;
using App.Infra.Data.Repos.Ef.Hw20.CarModel;

namespace App.Domain.AppServices.Hw20.CarModel
{
    public class CarModelAppService : ICarModelAppService
    {
        private readonly ICarModelService _carModelService;
        public readonly ICompanyAppService _companyAppService;

        public CarModelAppService(ICarModelService carModelService, ICompanyAppService companyAppService)
        {
            _carModelService = carModelService;
            _companyAppService = companyAppService;
        }

        public async Task<Result> Add(Core.Hw20.CarModel.Entities.CarModel carModel, CancellationToken cancellation)
        {
            var company = await _companyAppService.GetById(carModel.CompanyId, cancellation);
            if (company == null)
                return new Result(false, "Company Not Found!");
           return await _carModelService.Add(carModel , cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _carModelService.Delete(id, cancellation);
        }

        public async Task<List<CarModelDto>> GetAll(CancellationToken cancellation)
        {
           return await _carModelService.GetAll(cancellation);
        }

        public async Task<CarModelDto> GetDtoById(int id, CancellationToken cancellation)
        {
            return await _carModelService.GetDtoById(id, cancellation);
        }

        public async Task<Core.Hw20.CarModel.Entities.CarModel> GetByName(string str, CancellationToken cancellation)
        {
           return await _carModelService.GetByName(str, cancellation);
        }

        public async Task<Result> Update(int id, string name, Core.Hw20.Company.Entities.Company company, CancellationToken cancellation)
        {
            if (company is null)
                return new Result(false, "Company Not Found!");
            return await _carModelService.Update(id, name, company , cancellation);
        }

        public async Task<Core.Hw20.CarModel.Entities.CarModel> GetById(int id , CancellationToken cancellation)
        {
            return await _carModelService.GetById(id , cancellation);
        }

       
    }
}
