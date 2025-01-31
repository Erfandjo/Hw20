using App.Domain.Core.Hw20.Car.Data;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Hw20.Car
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Domain.Core.Hw20.Car.Entities.Car> GetByLicensePlate(string licensePlate, CancellationToken cancellation)
        {
           return await _appDbContext.Cars.AsNoTracking().Include(x => x.CarModel)
                .Include(x => x.CarModel.Company)
                .FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);
        }
    }
}
