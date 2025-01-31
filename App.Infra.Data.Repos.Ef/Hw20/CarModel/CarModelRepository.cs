using App.Domain.Core.Hw20.CarModel.Data;
using App.Domain.Core.Hw20.Result;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Hw20.CarModel
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly AppDbContext _dbContext;

        public CarModelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result> Add(Domain.Core.Hw20.CarModel.Entities.CarModel carModel , CancellationToken cancellation)
        {
            if (carModel == null)
                return new Result(false, "Car Model Is Null");
      

            await _dbContext.CarModels.AddAsync(carModel);
               await _dbContext.SaveChangesAsync();
                return new Result(true , "Success");
            
            
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var car = await _dbContext.CarModels.FirstOrDefaultAsync(x => x.Id == id);
            if (car != null)
            {
                _dbContext.Remove(car);
               await _dbContext.SaveChangesAsync();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found");
        }

        public async Task<List<CarModelDto>> GetAll(CancellationToken cancellation)
        {
            return await _dbContext.CarModels
                .AsNoTracking()
                .Include(x => x.Company)
                .Select(x => new CarModelDto{ Id = x.Id, CompanyId = x.CompanyId, CompanyName = x.Company.Name, Name = x.Name })
                .ToListAsync();
        }

        public async Task<CarModelDto> GetDtoById(int id, CancellationToken cancellation)
        {
            return await _dbContext.CarModels
                .AsNoTracking()
                .Include(x => x.Company)
                .Select(x => new CarModelDto { Id = x.Id, CompanyId = x.CompanyId, CompanyName = x.Company.Name, Name = x.Name })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Domain.Core.Hw20.CarModel.Entities.CarModel> GetByName(string str, CancellationToken cancellation)
        {
            return await _dbContext.CarModels
                .AsNoTracking()
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Name == str)
                ;
                ;
        }

        public async Task<Result> Update(int id, string name, Domain.Core.Hw20.Company.Entities.Company company, CancellationToken cancellation)
        {
            var car = await _dbContext.CarModels
                .FirstOrDefaultAsync(x => x.Id == id);
            if (car != null)
            {
                car.Name = name;
                car.Company = company;
               await _dbContext.SaveChangesAsync();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found");
        }

        public async Task<Domain.Core.Hw20.CarModel.Entities.CarModel> GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.CarModels
                .AsNoTracking()
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
