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
using Hw20.Endpoints.Mvc.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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


        public IActionResult SignUp()
        {
            AccountPageResultViewModel model = new AccountPageResultViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AccountPageResultViewModel page)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _userAppService.SignUp(page.loginViewModel.Username, page.loginViewModel.Password);
                if (!result.Succeeded)
                {
                    page.SignUpResult = result;
                    return View(page);
                }
                return RedirectToAction("Login");
            }
            else
            {
                return View(page);
            }

        }

        public IActionResult Login()
        {
            AccountPageResultViewModel model = new AccountPageResultViewModel();
           
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Login(AccountPageResultViewModel page)
        {
            if (ModelState.IsValid)
            {
                var result = await _userAppService.Login(page.loginViewModel.Username, page.loginViewModel.Password);
                if (!result.Succeeded)
                {
                    page.LoginMessage = "Username or password is incorrect";
                    return View(page);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(page);
            }

        }




        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RequestList(DateOnly date, CancellationToken cancellation, int? value = 0)
        {
          
            
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CarList(CancellationToken cancellation)
        {
          

            var carModels = await _carModelAppService.GetAll(cancellation);
            return View(carModels);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCarList(CancellationToken cancellation , string errorMessage = null)
        {
          

            ViewBag.errorMessage = errorMessage;
            var company = await _companyAppService.GetAll(cancellation);
            return View(company);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCarModel(string name, string company , CancellationToken cancellation)
        {
          

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCarList(int id , CancellationToken cancellation, string errorMessage = null)
        {
           

            ViewBag.errorMessage = errorMessage;
            var carModel = await _carModelAppService.GetById(id , cancellation);
            var companies = await _companyAppService.GetAll(cancellation);
            var viewModel = new UpdateCarModelViewModel();
            viewModel.CarModel = carModel;
            viewModel.Companies = companies;
            return View(viewModel);
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCarModel(int id , string name , string company , CancellationToken cancellation)
        {
          

            var co = await _companyAppService.GetByName(company , cancellation);
            var result = await _carModelAppService.Update(id, name, co , cancellation);
            if (!result.IsSucces)
            {
                return RedirectToAction("UpdateCarList", new { errorMessage = result.Message });
            }
            return RedirectToAction("CarList");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PreviewCarList(int id , CancellationToken cancellation)
        {
           

            
            var carModel = await _carModelAppService.GetById(id , cancellation);
            return View(carModel);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AcceptRequest(int id , CancellationToken cancellation)
        {
            

           await _requestAppService.AcceptRequest(id, cancellation);
            return RedirectToAction("RequestList");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRequest(int id, CancellationToken cancellation)
        {
            

           await _requestAppService.RejectRequest(id, cancellation);
            return RedirectToAction("RequestList");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCarModel(int id, CancellationToken cancellation) 
        {
           

           await _carModelAppService.Delete(id, cancellation);
            return RedirectToAction("CarList");
        }

    }
}
