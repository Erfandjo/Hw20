using App.Domain.Core.Hw20.User.Data;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Hw20.User.Service
{
    public interface IUserService
    {
        public Task<IdentityResult> Login(string phoneNumber, string nationalCode , CancellationToken cancellation);
        public Task<User.Entities.User> GetByNationalCode(string nationalCode, CancellationToken cancellation);


    }
}
