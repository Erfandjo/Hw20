using App.Domain.Core.Hw20.Request.Entities;

namespace App.Domain.Core.Hw20.Request.Data
{
    public interface IRequestRepository
    {

        public Result.Result Add(Request.Entities.Request request);
        public int CountRequestOfDay(DateOnly d);
        public Request.Entities.Request GetLastRequestForCar(int carId);
        public List<Request.Entities.Request> GetAll();
        public List<Request.Entities.Request> GetAccept();
        public List<Request.Entities.Request> GetReject();
        public List<Request.Entities.Request> GetPending();
        public List<Request.Entities.Request> GetByDate(DateOnly date);
        public Result.Result AcceptRequest(int id);
        public Result.Result RejectRequest(int id);

    }
}
