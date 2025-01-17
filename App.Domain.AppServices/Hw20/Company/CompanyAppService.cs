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

        public List<Core.Hw20.Company.Entities.Company> GetAll()
        {
            return _companyService.GetAll();
        }

        public Core.Hw20.Company.Entities.Company GetByName(string name)
        {
            return _companyService.GetByName(name);
        }
    }
}
