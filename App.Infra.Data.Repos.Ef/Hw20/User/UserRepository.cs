using App.Domain.Core.Hw20.User.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Hw20.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Core.Hw20.User.Entities.User> GetByNationalCode(string nationalCode , CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.NationalCode == nationalCode && x.RoleId == 1);
        }

        public async Task<bool> Login(string phoneNumber, string nationalCode , CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .AnyAsync(x => x.PhoneNumber == phoneNumber && x.NationalCode == nationalCode && x.RoleId == 1);
        }
    }
}
