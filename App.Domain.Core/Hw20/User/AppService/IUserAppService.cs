using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Hw20.User.AppService
{
    public interface IUserAppService
    {
        public Task<IdentityResult> Login(string username, string password);
        public Task<IdentityResult> SignUp(string username,string password);
        
    }
}
