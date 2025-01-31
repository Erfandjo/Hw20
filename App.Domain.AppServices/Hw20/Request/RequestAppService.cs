using App.Domain.Core.Hw20.Log.AppService;
using App.Domain.Core.Hw20.Log.Entities;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Service;
using App.Domain.Core.Hw20.Result;
using Microsoft.Extensions.Configuration;
using System.Threading;

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

        public async Task<Result> AcceptRequest(int id , CancellationToken cancellationToken)
        {
          return await _requestService.AcceptRequest(id , cancellationToken);
        }

        public async Task<Result> Add(Core.Hw20.Request.Entities.Request request , CancellationToken cancellationToken)
        {
            int maxReqFard = Convert.ToInt32(_appsetting["RozMayene:Fard"]);
            int maxReqZoj = Convert.ToInt32(_appsetting["RozMayene:Zoj"]);
            var lastRequest = await _requestService.GetLastRequestForCar(request.Car.Id , cancellationToken);
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
               await _logAppService.Add(log, cancellationToken);

                return new Result(false, "Your car is more than 5 years old");
            }
                
            if(WeekOfDay(request.DateVisit) == "fard" && request.Car.CarModel.Company.Name == "IranKhodro")
                return new Result(false , "You can visit on even days");
            if (WeekOfDay(request.DateVisit) == "zoj" && request.Car.CarModel.Company.Name == "Shaipa")
                return new Result(false, "You can visit on odd days");
            if (WeekOfDay(request.DateVisit) == "zoj" && await _requestService.CountRequestOfDay(request.DateVisit , cancellationToken) > maxReqZoj)
                return new Result(false, "Capacity filled");
            if (WeekOfDay(request.DateVisit) == "fard" && await _requestService.CountRequestOfDay(request.DateVisit , cancellationToken) > maxReqFard)
                return new Result(false, "Capacity filled");
            if(lastRequest is not null)
            if (request.DateVisit.Year <= lastRequest.DateVisit.Year + 1 && request.StatusRequest != Core.Hw20.Request.Enum.StatusRequestEnum.Reject)
                return new Result(false, "You can visit every year");

            return await _requestService.Add(request , cancellationToken);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetAccept(CancellationToken cancellationToken)
        {
            return await _requestService.GetAccept(cancellationToken);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetAll(CancellationToken cancellationToken)
        {
            return await _requestService.GetAll(cancellationToken);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetByDate(DateOnly date  , CancellationToken cancellationToken)
        {
            return await _requestService.GetByDate(date, cancellationToken);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetPending(CancellationToken cancellationToken)
        {
            return await _requestService.GetPending(cancellationToken);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetReject(CancellationToken cancellationToken)
        {
            return await _requestService.GetReject(cancellationToken);
        }

        public async Task<Result> RejectRequest(int id , CancellationToken cancellationToken)
        {
            return await _requestService.RejectRequest(id , cancellationToken);
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
