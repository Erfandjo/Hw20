using App.Domain.Core.Hw20.User.AppService;
using App.Domain.Core.Hw20.User.Service;
using App.Infra.Data.Db.Storage.Memory;

namespace App.Domain.AppServices.Hw20.User
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

       

        public async Task<bool> Login(string phoneNumber, string nationalCode , CancellationToken cancellation)
        {
            var result = await _userService.Login(phoneNumber, nationalCode , cancellation);
            if (result == true)
            {
                CurrentUser.OnlineUser = await _userService.GetByNationalCode(nationalCode , cancellation);
            } 
            return result;
        }
    }
}
