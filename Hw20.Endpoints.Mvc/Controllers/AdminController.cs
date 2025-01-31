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

        public async Task<IActionResult> RequestList(DateOnly date , int? value = 0 , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");
            
            var request = new List<App.Domain.Core.Hw20.Request.Entities.Request>();
            if (value == 0)
            {
                request = await _requestAppService.GetAll(cancellation);
            } else if (value == 1)
            {
                request = await _requestAppService.GetPending(cancellation);
            } else if (value == 2)
            {
                request = await _requestAppService.GetAccept(cancellation);
            }
            else if (value == 3)
            {
                request = await _requestAppService.GetReject(cancellation);
            }
            else if (value == 4)
            {
                request = await _requestAppService.GetByDate(date , cancellation);
            }

            return View(request);
        }


        public async Task<IActionResult> CarList(CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var carModels = await _carModelAppService.GetAll(cancellation);
            return View(carModels);
        }

        public async Task<IActionResult> AddCarList(string errorMessage = null , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            ViewBag.errorMessage = errorMessage;
            var company = await _companyAppService.GetAll(cancellation);
            return View(company);
        }

        public async Task<IActionResult> AddCarModel(string name, string company , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var co = await _companyAppService.GetByName(company , cancellation);
            var carModel = new CarModel();
            carModel.Name = name;
            carModel.Company = co;
            var result = await _carModelAppService.Add(carModel , cancellation);
            if(!result.IsSucces)
            {
                return RedirectToAction("AddCarList", new { errorMessage = result.Message });
            }
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> UpdateCarList(int id , string errorMessage = null , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            ViewBag.errorMessage = errorMessage;
            var carModel = await _carModelAppService.GetById(id , cancellation);
            var companies = await _companyAppService.GetAll(cancellation);
            var viewModel = new UpdateCarModelViewModel();
            viewModel.CarModel = carModel;
            viewModel.Companies = companies;
            return View(viewModel);
        }

        public async Task<IActionResult> UpdateCarModel(int id , string name , string company , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            var co = await _companyAppService.GetByName(company , cancellation);
            var result = await _carModelAppService.Update(id, name, co , cancellation);
            if (!result.IsSucces)
            {
                return RedirectToAction("UpdateCarList", new { errorMessage = result.Message });
            }
            return RedirectToAction("CarList");
        }

        public async Task<IActionResult> PreviewCarList(int id , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

            
            var carModel = await _carModelAppService.GetById(id , cancellation);
            return View(carModel);
        }

        public async Task<IActionResult> LoginUser(string PhoneNumber, string NationalCode, CancellationToken cancellation)
        {
          var result = await _userAppService.Login(PhoneNumber, NationalCode , cancellation);
            if (!result)
            {
                return RedirectToAction("Login", new { errorMessage = "User Is not Found." });
            }
            return RedirectToAction("Index" , "Home");
        }

        public async Task<IActionResult> AcceptRequest(int id , CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

           await _requestAppService.AcceptRequest(id, cancellation);
            return RedirectToAction("RequestList");
        }

        public async Task<IActionResult> RejectRequest(int id, CancellationToken cancellation)
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

           await _requestAppService.RejectRequest(id, cancellation);
            return RedirectToAction("RequestList");
        }

        public async Task<IActionResult> DeleteCarModel(int id, CancellationToken cancellation) 
        {
            if (CurrentUser.OnlineUser == null)
                return RedirectToAction("Login");

           await _carModelAppService.Delete(id, cancellation);
            return RedirectToAction("CarList");
        }

    }
}
