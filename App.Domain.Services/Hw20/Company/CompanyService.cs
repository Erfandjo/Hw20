using App.Domain.Core.Hw20.Company.Data;
using App.Domain.Core.Hw20.Company.Service;

namespace App.Domain.Services.Hw20.Company
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<Core.Hw20.Company.Entities.Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public Core.Hw20.Company.Entities.Company GetByName(string name)
        {
            return _companyRepository.GetByName(name);
        }
    }
}
