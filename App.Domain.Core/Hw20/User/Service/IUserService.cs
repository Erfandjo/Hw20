using App.Domain.Core.Hw20.User.Data;

namespace App.Domain.Core.Hw20.User.Service
{
    public interface IUserService
    {
        public bool Login(string phoneNumber, string nationalCode);
        public User.Entities.User GetByNationalCode(string nationalCode);


    }
}
