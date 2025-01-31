using App.Domain.Core.Hw20.User.Entities;

namespace App.Domain.Core.Hw20.User.Data
{
    public interface IUserRepository
    {
        public Task<bool> Login(string phoneNumber, string nationalCode, CancellationToken cancellation);
        public Task<User.Entities.User> GetByNationalCode(string nationalCode, CancellationToken cancellation);
    }
}
