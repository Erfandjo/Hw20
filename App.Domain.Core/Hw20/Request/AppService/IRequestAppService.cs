namespace App.Domain.Core.Hw20.Request.AppService
{
    public interface IRequestAppService
    {

        public Result.Result Add(Request.Entities.Request request);
        public List<Request.Entities.Request> GetAll();
        public List<Request.Entities.Request> GetAccept();
        public List<Request.Entities.Request> GetReject();
        public List<Request.Entities.Request> GetPending();
        public List<Request.Entities.Request> GetByDate(DateOnly date);
        public Result.Result AcceptRequest(int id);
        public Result.Result RejectRequest(int id);
    }
}
