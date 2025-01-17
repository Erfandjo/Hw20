using App.Domain.Core.Hw20.User.Entities;

namespace App.Domain.Core.Hw20.User.Data
{
    public interface IUserRepository
    {
        public bool Login(string phoneNumber, string nationalCode);
        public User.Entities.User GetByNationalCode(string nationalCode);
    }
}
