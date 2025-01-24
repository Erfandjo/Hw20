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

        public Result AcceptRequest(int id)
        {
            var item =_appDbContext.Requests.FirstOrDefault(x => x.Id == id);
            if(item is not null)
            {
                item.StatusRequest = Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept;
                _appDbContext.SaveChanges();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found Item");
        }

        public Result Add(Domain.Core.Hw20.Request.Entities.Request request)
        {
            Result result = new Result(true , "Success");
            if (request != null)
            {
                _appDbContext.Add(request);
                _appDbContext.SaveChanges();
                return result;
            }

            result.IsSucces = false;
            result.Message = "Request is Null";
            return result;
            
        }

        public int CountRequestOfDay(DateOnly d)
        {
           return _appDbContext.Requests.Where(x => x.DateVisit.DayOfYear == d.DayOfYear && x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept).Count();
        }

        public List<Domain.Core.Hw20.Request.Entities.Request> GetAccept()
        {
            return _appDbContext.Requests.Include(x => x.Car).Include(x => x.Car.CarModel.Company).Include(x => x.User).Where(x =>  x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Accept).ToList();
        }

        public List<Domain.Core.Hw20.Request.Entities.Request> GetAll()
        {
            return _appDbContext.Requests.Include(x => x.Car).Include(x => x.Car.CarModel.Company).Include(x => x.User).ToList();
        }

        public List<Domain.Core.Hw20.Request.Entities.Request> GetByDate(DateOnly date)
        {
            return _appDbContext.Requests.Include(x => x.Car).Include(x => x.Car.CarModel.Company).Include(x => x.User)
                .Where(x => x.DateVisit == date).ToList();
        }

        public Domain.Core.Hw20.Request.Entities.Request GetLastRequestForCar(int carId)
        {
            return _appDbContext.Requests.OrderByDescending(x => x.Id).FirstOrDefault(x => x.CarId == carId);
        }

        public List<Domain.Core.Hw20.Request.Entities.Request> GetPending()
        {
            return _appDbContext.Requests.Include(x => x.Car).Include(x => x.Car.CarModel.Company).Include(x => x.User).Where(x => x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.IsPending).ToList();
        }

        public List<Domain.Core.Hw20.Request.Entities.Request> GetReject()
        {
            return _appDbContext.Requests.Include(x => x.Car).Include(x => x.Car.CarModel.Company).Include(x => x.User).Where(x => x.StatusRequest == Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Reject).ToList();
        }

        public Result RejectRequest(int id)
        {
            var item = _appDbContext.Requests.FirstOrDefault(x => x.Id == id);
            if (item is not null)
            {
                item.StatusRequest = Domain.Core.Hw20.Request.Enum.StatusRequestEnum.Reject;
                _appDbContext.SaveChanges();
                return new Result(true, "Success");
            }
            return new Result(false, "Not Found Item");
        }
    }
}
