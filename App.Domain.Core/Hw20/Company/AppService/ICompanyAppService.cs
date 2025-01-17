namespace App.Domain.Core.Hw20.Company.AppService
{
    public interface ICompanyAppService
    {
        public List<Company.Entities.Company> GetAll();
        public Company.Entities.Company GetByName(string name);
    }
}
