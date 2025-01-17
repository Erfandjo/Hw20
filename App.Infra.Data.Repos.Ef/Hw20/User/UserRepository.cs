using App.Domain.Core.Hw20.User.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;

namespace App.Infra.Data.Repos.Ef.Hw20.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Domain.Core.Hw20.User.Entities.User GetByNationalCode(string nationalCode)
        {
            return _dbContext.Users.FirstOrDefault(x => x.NationalCode == nationalCode && x.RoleId == 1);
        }

        public bool Login(string phoneNumber, string nationalCode)
        {
            return _dbContext.Users.Any(x => x.PhoneNumber == phoneNumber && x.NationalCode == nationalCode && x.RoleId == 1);
        }
    }
}
