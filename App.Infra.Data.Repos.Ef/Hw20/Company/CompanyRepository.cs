using App.Domain.Core.Hw20.Company.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Hw20.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Core.Hw20.Company.Entities.Company>> GetAll(CancellationToken cancellation)
        {
           return await _dbContext.Companies
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Domain.Core.Hw20.Company.Entities.Company> GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Domain.Core.Hw20.Company.Entities.Company> GetByName(string name, CancellationToken cancellation)
        {
            return await _dbContext.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

        }
    }
}
