using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Dto;
using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Company.AppService;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Result;
using App.Domain.Core.Hw20.User.AppService;
using App.Infra.Data.Db.Storage.Memory;
using App.Infra.Data.Repos.Ef.Hw20.CarModel;
using Microsoft.AspNetCore.Mvc;

namespace Hw20.Endpoints.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IRequestAppService _requestAppService;
        private readonly ICarModelAppService _carModelAppService;
        private readonly ICompanyAppService _companyAppService;

        public AdminController(IUserAppService userAppService, IRequestAppService requestAppService, ICarModelAppService carModelAppService, ICompanyAppService companyAppService)
        {
            _userAppService = userAppService;
            _requestAppService = requestAppService;
            _carModelAppService = carModelAppService;
            _companyAppService = companyAppService;
        }

        [HttpGet("[action]")]
        public async Task<List<CarModelDto>> GetCarModelList(CancellationToken cancellation)
        {
            var carModels = await _carModelAppService.GetAll(cancellation);
            return carModels;
        }

        [HttpGet("[action]")]
        public async Task<CarModelDto> GetCarModelById(int id , CancellationToken cancellationToken)
        {
            var carModel = await _carModelAppService.GetDtoById(id , cancellationToken);
            return carModel;
        }

        [HttpPost("[action]")]
        public async Task<Result> AddCarModel(AddCarModelDto carModel , CancellationToken cancellationToken)
        {
            CarModel c = new CarModel();
            c.Name = carModel.Name;
            c.CompanyId = carModel.CompanyId;
            var result = await _carModelAppService.Add(c , cancellationToken);
            return result;
        }


        [HttpPost("[action]")]
        public async Task<Result> UpdateCarModel(UpdateCarModelDto carModel , CancellationToken cancellationToken)
        {
            var company = await _companyAppService.GetById(carModel.CompanyId , cancellationToken);
            var result = await _carModelAppService.Update(carModel.Id , carModel.Name , company , cancellationToken);
            return result;
        }

        [HttpPost("[action]")]
        public async Task<Result> DeleteCarModel(int id , CancellationToken cancellationToken)
        {
            var result = await _carModelAppService.Delete(id, cancellationToken);
            return result;
        }

      

        

    }
}
