using App.Domain.Core.Hw20.Request.Data;
using App.Domain.Core.Hw20.Result;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Hw20.Request
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _appDbContext;

        public RequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result> AcceptRequest(int id, CancellationToken cancellation)
        {
            var item = await _appDbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if(item is not null)
            {
                item.StatusRequest = Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept;
               await _appDbContext.SaveChangesAsync();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found Item");
        }

        public async Task<Result> Add(Domain.Core.Hw20.Request.Entities.Request request, CancellationToken cancellation)
        {
            request.Car.CarModel = null;
            
            Result result = new Result(true , "Success");
            if (request != null)
            {
               await _appDbContext.AddAsync(request);
               _appDbContext.SaveChanges();
                return result;
            }

            result.IsSucces = false;
            result.Message = "Request is Null";
            return result;
            
        }

        public async Task<int> CountRequestOfDay(DateOnly d, CancellationToken cancellation)
        {
           return await _appDbContext.Requests
                .AsNoTracking()
                .Where(x => x.DateVisit.Year == d.Year && x.DateVisit.DayOfYear == d.DayOfYear && x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept)
                .CountAsync();
        }

        public async Task<List<Domain.Core.Hw20.Request.Entities.Request>> GetAccept(CancellationToken cancellation)
        {
            return await _appDbContext.Requests
                .AsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.Car.CarModel.Company)
                .Include(x => x.User)
                .Where(x =>  x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept)
                .ToListAsync();
        }

        public async Task<List<Domain.Core.Hw20.Request.Entities.Request>> GetAll(CancellationToken cancellation)
        {
            return await _appDbContext.Requests
                .AsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.Car.CarModel.Company)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<List<Domain.Core.Hw20.Request.Entities.Request>> GetByDate(DateOnly date, CancellationToken cancellation)
        {
            return await _appDbContext.Requests
                .AsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.Car.CarModel.Company)
                .Include(x => x.User)
                .Where(x => x.DateVisit == date)
                .ToListAsync();
        }

        public async Task<Domain.Core.Hw20.Request.Entities.Request> GetLastRequestForCar(int carId, CancellationToken cancellation)
        {
            return  await _appDbContext.Requests
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync(x => x.CarId == carId);
        }

        public async Task<List<Domain.Core.Hw20.Request.Entities.Request>> GetPending(CancellationToken cancellation)
        {
            return await _appDbContext.Requests
                .AsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.Car.CarModel.Company)
                .Include(x => x.User)
                .Where(x => x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.IsPending)
                .ToListAsync();
        }

        public async Task<List<Domain.Core.Hw20.Request.Entities.Request>> GetReject(CancellationToken cancellation)
        {
            return await _appDbContext.Requests
                .AsNoTracking()
                .Include(x => x.Car)
                .Include(x => x.Car.CarModel.Company)
                .Include(x => x.User)
                .Where(x => x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Reject)
                .ToListAsync();
        }

        public async Task<Result> RejectRequest(int id, CancellationToken cancellation)
        {
            var item = await _appDbContext.Requests
                .FirstOrDefaultAsync(x => x.Id == id);
            if (item is not null)
            {
                item.StatusRequest = Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Reject;
               await _appDbContext.SaveChangesAsync();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found Item");
        }
    }
}
