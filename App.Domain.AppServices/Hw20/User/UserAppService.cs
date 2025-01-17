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

       

        public bool Login(string phoneNumber, string nationalCode)
        {
            var result = _userService.Login(phoneNumber, nationalCode);
            if (result == true)
            {
                CurrentUser.OnlineUser = _userService.GetByNationalCode(nationalCode);
            } 
            return result;
        }
    }
}
