using App.Domain.Core.Hw20.User.AppService;
using App.Domain.Core.Hw20.User.Service;
using App.Infra.Data.Db.Storage.Memory;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.AppServices.Hw20.User
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly SignInManager<Domain.Core.Hw20.User.Entities.User> _signInManager;
        private readonly UserManager<Core.Hw20.User.Entities.User> _userManager;

        public UserAppService(IUserService userService, SignInManager<Core.Hw20.User.Entities.User> signInManager, UserManager<Core.Hw20.User.Entities.User> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }



        public async Task<IdentityResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> SignUp(string username, string password)
        {
            var u = new Core.Hw20.User.Entities.User();
            u.UserName = username;
            // u.RoleId = 1;


            var result = await _userManager.CreateAsync(u, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(u, "Admin");
            }

            return result;

        }
    }
}
