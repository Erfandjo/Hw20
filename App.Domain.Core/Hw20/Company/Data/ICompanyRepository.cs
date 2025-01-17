using App.Domain.Core.Hw20.Company.Entities;

namespace App.Domain.Core.Hw20.Company.Data
{
    public interface ICompanyRepository
    {
        public List<Company.Entities.Company> GetAll();
        public Company.Entities.Company GetByName(string name);
    }
}
