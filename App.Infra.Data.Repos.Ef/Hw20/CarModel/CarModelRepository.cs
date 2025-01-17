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

        public Result Add(Domain.Core.Hw20.CarModel.Entities.CarModel carModel)
        {
            if (carModel != null)
            {
                _dbContext.CarModels.Add(carModel);
                _dbContext.SaveChanges();
                return new Result(true , "Success");
            }
            return new Result(false, "Car Model Is Null");
        }

        public Result Delete(int id)
        {
            var car =_dbContext.CarModels.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _dbContext.Remove(car);
                _dbContext.SaveChanges();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found");
        }

        public List<Domain.Core.Hw20.CarModel.Entities.CarModel> GetAll()
        {
           return _dbContext.CarModels.Include(x => x.Company).ToList();
        }

        public Domain.Core.Hw20.CarModel.Entities.CarModel GetById(int id)
        {
            return _dbContext.CarModels.Include(x => x.Company).FirstOrDefault(x => x.Id == id);
        }

        public Domain.Core.Hw20.CarModel.Entities.CarModel GetByName(string str)
        {
            return _dbContext.CarModels.Include(x => x.Company)
                .FirstOrDefault(x => x.Name == str)
                ;
                ;
        }

        public Result Update(int id, string name, Domain.Core.Hw20.Company.Entities.Company company)
        {
            var car = _dbContext.CarModels.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                car.Name = name;
                car.Company = company;
                _dbContext.SaveChanges();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found");
        }
    }
}
