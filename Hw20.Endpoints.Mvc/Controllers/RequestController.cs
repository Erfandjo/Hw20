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


        public IActionResult Add(string errorMessage = null)
        {
            ViewBag.errorMessage = errorMessage;
            var CarModels = _carModelAppService.GetAll();
            return View(CarModels);
        }

        public IActionResult AddRequest(AddRequestViewModel addRequestViewModel)
        {
            Request request = new Request();
            var carModel = _carModelAppService.GetByName(addRequestViewModel.CarModel);
            var car = _carAppService.GetByLicensePlate(addRequestViewModel.LicensePlate);
            request.User = new User()
            {
                RoleId = 2,
                NationalCode = addRequestViewModel.NationalCode,
                Address = addRequestViewModel.Address,
                PhoneNumber = addRequestViewModel.PhoneNumber,
            };
            if(car is not null)
            {
                request.Car = car;
            }
            else
            {
                request.Car = new Car()
                {
                    LicensePlate = addRequestViewModel.LicensePlate,
                    YearOfCar = addRequestViewModel.YearOfCar,
                    CarModelId = carModel.Id,
                    CarModel = carModel
                };
            }
            request.DateVisit = addRequestViewModel.DateVisit;

            var result = _requestAppService.Add(request);
            if (!result.IsSucces)
            {
                return RedirectToAction("Add" , new { errorMessage = result.Message});
            }
            return RedirectToAction("Index");
        }

    }
}
