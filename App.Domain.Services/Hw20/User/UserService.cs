using App.Domain.Core.Hw20.User.Data;
using App.Domain.Core.Hw20.User.Service;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Services.Hw20.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Core.Hw20.User.Entities.User> GetByNationalCode(string nationalCode , CancellationToken cancellation)
        {
            return await _userRepository.GetByNationalCode(nationalCode , cancellation);
        }

        public async Task<IdentityResult> Login(string phoneNumber, string nationalCode , CancellationToken cancellationToken)
        {
           return await _userRepository.Login(phoneNumber, nationalCode , cancellationToken);
        }
    }
}
