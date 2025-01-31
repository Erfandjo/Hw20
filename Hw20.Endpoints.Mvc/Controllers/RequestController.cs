using App.Domain.Core.Hw20.Car.AppService;
using App.Domain.Core.Hw20.Car.Entities;
using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Dto;
using App.Domain.Core.Hw20.Request.Entities;
using App.Domain.Core.Hw20.User.Entities;
using Hw20.Endpoints.Mvc.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Hw20.Endpoints.Mvc.Controllers
{
    public class RequestController : Controller
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

        public IActionResult Index(int value = 0)
        {
            return View();
        }


        public IActionResult Add(string? errorMessage = null)
        {
            AddPageResultViewModel model = new();
            ViewBag.errorMessage = errorMessage;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddPageResultViewModel addPageResultViewModel , CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                Request request = new Request();
                var carModel = await _carModelAppService.GetByName(addPageResultViewModel.AddRequestViewModel.CarModel , cancellation);
                var car = await _carAppService.GetByLicensePlate(addPageResultViewModel.AddRequestViewModel.LicensePlate, cancellation);
                request.User = new User()
                {
                    RoleId = 2,
                    NationalCode = addPageResultViewModel.AddRequestViewModel.NationalCode,
                    Address = addPageResultViewModel.AddRequestViewModel.Address,
                    PhoneNumber = addPageResultViewModel.AddRequestViewModel.PhoneNumber,
                };
                if (car is not null)
                {
                    request.Car = car;
                }
                else
                {
                    request.Car = new Car()
                    {
                        LicensePlate = addPageResultViewModel.AddRequestViewModel.LicensePlate,
                        YearOfCar = addPageResultViewModel.AddRequestViewModel.YearOfCar,
                        CarModelId = carModel.Id,
                        CarModel = carModel
                    };
                }
                request.DateVisit = addPageResultViewModel.AddRequestViewModel.DateVisit;

                var result = await _requestAppService.Add(request, cancellation);
                if (!result.IsSucces)
                {
                    addPageResultViewModel.Result = result.Message;
                    return View(addPageResultViewModel);
                }
                return View("Index");
            }
            else
            {
                return View(addPageResultViewModel);
            }
           
        }

    }
}
