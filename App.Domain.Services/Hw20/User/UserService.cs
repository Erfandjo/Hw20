using App.Domain.Core.Hw20.User.Data;
using App.Domain.Core.Hw20.User.Service;

namespace App.Domain.Services.Hw20.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Core.Hw20.User.Entities.User GetByNationalCode(string nationalCode)
        {
            return _userRepository.GetByNationalCode(nationalCode);
        }

        public bool Login(string phoneNumber, string nationalCode)
        {
           return _userRepository.Login(phoneNumber, nationalCode);
        }
    }
}
