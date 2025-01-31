using App.Domain.Core.Hw20.Car.AppService;
using App.Domain.Core.Hw20.Car.Entities;
using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Dto;
using App.Domain.Core.Hw20.Request.Entities;
using App.Domain.Core.Hw20.Result;
using App.Domain.Core.Hw20.User.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hw20.Endpoints.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {

        private readonly ICarModelAppService _carModelAppService;
        private readonly IRequestAppService _requestAppService;
        private readonly ICarAppService _carAppService;

        public RequestController(ICarModelAppService carModelAppService, IRequestAppService requestAppService, ICarAppService carAppService)
        {
            _carModelAppService = carModelAppService;
            _requestAppService = requestAppService;
            _carAppService = carAppService;
        }

        [HttpPost("[action]")]
        public async Task<Result> Add(AddRequestDto addRequestDto , CancellationToken cancellationToken)
        {
            
                Request request = new Request();
                var carModel = await _carModelAppService.GetById(addRequestDto.CarModelId, cancellationToken);
                var car = await _carAppService.GetByLicensePlate(addRequestDto.LicensePlate, cancellationToken);
                request.User = new User()
                {
                    RoleId = 2,
                    NationalCode = addRequestDto.NationalCode,
                    Address = addRequestDto.Address,
                    PhoneNumber = addRequestDto.PhoneNumber,
                };
                if (car is not null)
                {
                    request.Car = car;
                }
                else
                {
                    request.Car = new Car()
                    {
                        LicensePlate = addRequestDto.LicensePlate,
                        YearOfCar = addRequestDto.YearOfCar,
                        CarModelId = carModel.Id,
                        CarModel = carModel
                    };
                }
                request.DateVisit = addRequestDto.DateVisit;

                var result = await _requestAppService.Add(request, cancellationToken);
                
                    return result;
               
            }
            

        }
    }

