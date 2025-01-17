using App.Domain.Core.Hw20.Company.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;

namespace App.Infra.Data.Repos.Ef.Hw20.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Domain.Core.Hw20.Company.Entities.Company> GetAll()
        {
           return _dbContext.Companies.ToList();
        }

        public Domain.Core.Hw20.Company.Entities.Company GetByName(string name)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.Name == name);

        }
    }
}
