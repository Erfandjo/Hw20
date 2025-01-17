using App.Domain.Core.Hw20.Request.Data;
using App.Domain.Core.Hw20.Request.Service;
using App.Domain.Core.Hw20.Result;

namespace App.Domain.Services.Hw20.Request
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Result AcceptRequest(int id)
        {
           return _requestRepository.AcceptRequest(id);
        }

        public Result Add(Core.Hw20.Request.Entities.Request request)
        {
            return _requestRepository.Add(request);
        }

        public int CountRequestOfDay(DateOnly d)
        {
            return _requestRepository.CountRequestOfDay(d);
        }

        public List<Core.Hw20.Request.Entities.Request> GetAccept()
        {
           return _requestRepository.GetAccept();
        }

        public List<Core.Hw20.Request.Entities.Request> GetAll()
        {
           return _requestRepository.GetAll();
        }

        public List<Core.Hw20.Request.Entities.Request> GetByDate(DateOnly date)
        {
            return _requestRepository.GetByDate(date);
        }

        public Core.Hw20.Request.Entities.Request GetLastRequestForCar(int carId)
        {
            return _requestRepository.GetLastRequestForCar(carId);
        }

        public List<Core.Hw20.Request.Entities.Request> GetPending()
        {
            return _requestRepository.GetPending();
        }

        public List<Core.Hw20.Request.Entities.Request> GetReject()
        {
            return _requestRepository.GetReject();
        }

        public Result RejectRequest(int id)
        {
            return _requestRepository.RejectRequest(id);
        }
    }
}
