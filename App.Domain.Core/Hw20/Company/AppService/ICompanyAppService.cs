namespace App.Domain.Core.Hw20.Company.AppService
{
    public interface ICompanyAppService
    {
        public Task<List<Company.Entities.Company>> GetAll(CancellationToken cancellationToken);
        public Task<Company.Entities.Company> GetByName(string name , CancellationToken cancellation);
        public Task<Company.Entities.Company> GetById(int id , CancellationToken cancellation);
    }
}
