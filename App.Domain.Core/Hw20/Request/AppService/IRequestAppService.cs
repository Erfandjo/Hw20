namespace App.Domain.Core.Hw20.Request.AppService
{
    public interface IRequestAppService
    {

        public Task<Result.Result> Add(Request.Entities.Request request , CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetAll(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetAccept(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetReject(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetPending(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetByDate(DateOnly date, CancellationToken cancellation);
        public Task<Result.Result> AcceptRequest(int id, CancellationToken cancellation);
        public Task<Result.Result> RejectRequest(int id, CancellationToken cancellation);
    }
}
