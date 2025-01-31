using App.Domain.Core.Hw20.Company.AppService;
using App.Domain.Core.Hw20.Company.Service;
using App.Domain.Services.Hw20.Company;

namespace App.Domain.AppServices.Hw20.Company
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyService;

        public CompanyAppService(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<List<Core.Hw20.Company.Entities.Company>> GetAll(CancellationToken cancellation)
        {
            return await _companyService.GetAll(cancellation);
        }

        public async Task<Core.Hw20.Company.Entities.Company> GetById(int id , CancellationToken cancellation)
        {
            return await _companyService.GetById(id, cancellation);
        }

        public async Task<Core.Hw20.Company.Entities.Company> GetByName(string name , CancellationToken cancellation)
        {
            return await _companyService.GetByName(name , cancellation);
        }
    }
}
