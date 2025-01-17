using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Company.AppService;
using App.Domain.Core.Hw20.Company.Entities;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Entities;
using App.Domain.Core.Hw20.User.AppService;
using App.Infra.Data.Db.Storage.Memory;
using Azure.Core;
using Hw20.Endpoints.Mvc.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Hw20.Endpoints.Mvc.Controllers
{
    public class AdminController : Controller
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

        public IActionResult Login(string errorMessage = null)
        {
            ViewBag.errorMessage = errorMessage;
            return View();
        }

        public IActionResult RequestList(DateOnly date , int? value = 0)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");
            
            var request = new List<App.Domain.Core.Hw20.Request.Entities.Request>();
            if (value == 0)
            {
                request = _requestAppService.GetAll();
            } else if (value == 1)
            {
                request = _requestAppService.GetPending();
            } else if (value == 2)
            {
                request = _requestAppService.GetAccept();
            }
            else if (value == 3)
            {
                request = _requestAppService.GetReject();
            }
            else if (value == 4)
            {
                request = _requestAppService.GetByDate(date);
            }

            return View(request);
        }


        public IActionResult CarList()
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var carModels = _carModelAppService.GetAll();
            return View(carModels);
        }

        public IActionResult AddCarList(string errorMessage = null)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            ViewBag.errorMessage = errorMessage;
            var company = _companyAppService.GetAll();
            return View(company);
        }

        public IActionResult AddCarModel(string name, string company)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var co = _companyAppService.GetByName(company);
            var carModel = new CarModel();
            carModel.Name = name;
            carModel.Company = co;
            var result = _carModelAppService.Add(carModel);
            if(!result.IsSucces)
            {
                return RedirectToAction("AddCarList", new { errorMessage = result.Message });
            }
            return RedirectToAction("CarList");
        }

        public IActionResult UpdateCarList(int id , string errorMessage = null)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            ViewBag.errorMessage = errorMessage;
            var carModel = _carModelAppService.GetById(id);
            var companies = _companyAppService.GetAll();
            var viewModel = new UpdateCarModelViewModel();
            viewModel.CarModel = carModel;
            viewModel.Companies = companies;
            return View(viewModel);
        }

        public IActionResult UpdateCarModel(int id , string name , string company)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var co = _companyAppService.GetByName(company);
            var result = _carModelAppService.Update(id, name, co);
            if (!result.IsSucces)
            {
                return RedirectToAction("UpdateCarList", new { errorMessage = result.Message });
            }
            return RedirectToAction("CarList");
        }

        public IActionResult PreviewCarList(int id)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            
            var carModel = _carModelAppService.GetById(id);
            return View(carModel);
        }

        public IActionResult LoginUser(string PhoneNumber, string NationalCode)
        {
          var result = _userAppService.Login(PhoneNumber, NationalCode);
            if (!result)
            {
                return RedirectToAction("Login", new { errorMessage = "User Is not Found." });
            }
            return RedirectToAction("Index" , "Home");
        }

        public IActionResult AcceptRequest(int id)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            _requestAppService.AcceptRequest(id);
            return RedirectToAction("RequestList");
        }

        public IActionResult RejectRequest(int id)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            _requestAppService.RejectRequest(id);
            return RedirectToAction("RequestList");
        }

        public IActionResult DeleteCarModel(int id) 
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            _carModelAppService.Delete(id);
            return RedirectToAction("CarList");
        }

    }
}
