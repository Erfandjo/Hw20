using App.Domain.Core.Hw20.User.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Hw20.User.Data
{
    public interface IUserRepository
    {
        public Task<IdentityResult> Login(string phoneNumber, string nationalCode, CancellationToken cancellation);
        public Task<User.Entities.User> GetByNationalCode(string nationalCode, CancellationToken cancellation);
    }
}
