namespace App.Domain.Core.Hw20.Company.Service
{
    public interface ICompanyService
    {
        public Task<List<Company.Entities.Company>> GetAll(CancellationToken cancellation);
        public Task<Company.Entities.Company> GetByName(string name , CancellationToken cancellation);
        public Task<Company.Entities.Company> GetById(int id , CancellationToken cancellation);
    }
}
