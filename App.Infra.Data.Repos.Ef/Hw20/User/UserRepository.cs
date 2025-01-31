using App.Domain.Core.Hw20.User.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace App.Infra.Data.Repos.Ef.Hw20.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly SignInManager<Domain.Core.Hw20.User.Entities.User> _signInManager;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Core.Hw20.User.Entities.User> GetByNationalCode(string nationalCode , CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.NationalCode == nationalCode && x.RoleId == 1);
        }

        public async Task<IdentityResult> Login(string userName, string password , CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true , false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }
    }
}
