using App.Domain.Core.Hw20.Car.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;

namespace App.Infra.Data.Repos.Ef.Hw20.Car
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Domain.Core.Hw20.Car.Entities.Car GetByLicensePlate(string licensePlate)
        {
           return _appDbContext.Cars.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }
    }
}
