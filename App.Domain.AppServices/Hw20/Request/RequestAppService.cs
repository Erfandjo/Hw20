using App.Domain.Core.Hw20.Log.AppService;
using App.Domain.Core.Hw20.Log.Entities;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Service;
using App.Domain.Core.Hw20.Result;
using Microsoft.Extensions.Configuration;

namespace App.Domain.AppServices.Hw20.Request
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        private readonly ILogAppService _logAppService;
        private readonly IConfiguration _appsetting;

        public RequestAppService(IRequestService requestService, ILogAppService logAppService, IConfiguration appsetting)
        {
            _requestService = requestService;
            _logAppService = logAppService;
            _appsetting = appsetting;
        }

        public Result AcceptRequest(int id)
        {
          return  _requestService.AcceptRequest(id);
        }

        public Result Add(Core.Hw20.Request.Entities.Request request)
        {
            int maxReqFard = Convert.ToInt32(_appsetting["RozMayene:Fard"]);
            int maxReqZoj = Convert.ToInt32(_appsetting["RozMayene:Zoj"]);
            var lastRequest = _requestService.GetLastRequestForCar(request.Car.Id);
            request.RequestAt = DateTime.Now;
            request.StatusRequest = Core.Hw20.Request.Enum.StatusRequestEnum.IsPending;
            if (request.Car.YearOfCar + 5 < DateTime.Now.Year)
            {
                var log = new Core.Hw20.Log.Entities.Log()
                {
                  
                   User = request.User,
                    Car = request.Car,
                    RequestAt = DateTime.Now,
                    DateVisit = request.DateVisit,
                    StatusRequest = Core.Hw20.Request.Enum.StatusRequestEnum.Reject
                };
                _logAppService.Add(log);

                return new Result(false, "Your car is more than 5 years old");
            }
                
            if(WeekOfDay(request.DateVisit) == "fard" && request.Car.CarModel.Company.Name == "IranKhodro")
            return new Result(false , "You can visit on even days");
            if (WeekOfDay(request.DateVisit) == "zoj" && request.Car.CarModel.Company.Name == "Shaipa")
                return new Result(false, "You can visit on odd days");
            if (WeekOfDay(request.DateVisit) == "zoj" && _requestService.CountRequestOfDay(request.DateVisit) > maxReqZoj)
                return new Result(false, "Capacity filled");
            if (WeekOfDay(request.DateVisit) == "fard" && _requestService.CountRequestOfDay(request.DateVisit) > maxReqFard)
                return new Result(false, "Capacity filled");
            if(lastRequest is not null)
            if (request.DateVisit.Year <= lastRequest.DateVisit.Year + 1 && request.StatusRequest != Core.Hw20.Request.Enum.StatusRequestEnum.Reject)
                return new Result(false, "You can visit every year");

            return _requestService.Add(request);
        }

        public List<Core.Hw20.Request.Entities.Request> GetAccept()
        {
            return _requestService.GetAccept();
        }

        public List<Core.Hw20.Request.Entities.Request> GetAll()
        {
            return _requestService.GetAll();
        }

        public List<Core.Hw20.Request.Entities.Request> GetByDate(DateOnly date)
        {
            return _requestService.GetByDate(date);
        }

        public List<Core.Hw20.Request.Entities.Request> GetPending()
        {
            return _requestService.GetPending();
        }

        public List<Core.Hw20.Request.Entities.Request> GetReject()
        {
            return _requestService.GetReject();
        }

        public Result RejectRequest(int id)
        {
            return _requestService.RejectRequest(id);
        }

        public string WeekOfDay(DateOnly d)
        {
            string weekOfDay = "zoj";

            if (d.DayOfWeek == DayOfWeek.Sunday)
                weekOfDay = "fard";

            else if (d.DayOfWeek == DayOfWeek.Tuesday)
                weekOfDay = "fard";

            else if (d.DayOfWeek == DayOfWeek.Thursday)
                weekOfDay = "fard";

            return weekOfDay;

        }
    }
}
