namespace App.Domain.Core.Hw20.Company.Service
{
    public interface ICompanyService
    {
        public List<Company.Entities.Company> GetAll();
        public Company.Entities.Company GetByName(string name);
    }
}
