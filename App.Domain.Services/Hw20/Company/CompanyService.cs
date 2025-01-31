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

        public async Task<List<Core.Hw20.Company.Entities.Company>> GetAll(CancellationToken cancellationToken)
        {
            return await _companyRepository.GetAll(cancellationToken);
        }

        public async Task<Core.Hw20.Company.Entities.Company> GetById(int id , CancellationToken cancellation)
        {
            return await _companyRepository.GetById(id , cancellation);
        }

        public async Task<Core.Hw20.Company.Entities.Company> GetByName(string name , CancellationToken cancellationToken)
        {
            return await _companyRepository.GetByName(name , cancellationToken);
        }
    }
}
