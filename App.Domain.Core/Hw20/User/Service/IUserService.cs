using App.Domain.Core.Hw20.User.Data;

namespace App.Domain.Core.Hw20.User.Service
{
    public interface IUserService
    {
        public Task<bool> Login(string phoneNumber, string nationalCode , CancellationToken cancellation);
        public Task<User.Entities.User> GetByNationalCode(string nationalCode, CancellationToken cancellation);


    }
}
