using App.Domain.Core.Hw20.Request.Entities;

namespace App.Domain.Core.Hw20.Request.Data
{
    public interface IRequestRepository
    {

        public Task<Result.Result> Add(Request.Entities.Request request , CancellationToken cancellation);
        public Task<int> CountRequestOfDay(DateOnly d, CancellationToken cancellation);
        public Task<Request.Entities.Request> GetLastRequestForCar(int carId, CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetAll(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetAccept(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetReject(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetPending(CancellationToken cancellation);
        public Task<List<Request.Entities.Request>> GetByDate(DateOnly date, CancellationToken cancellation);
        public Task<Result.Result> AcceptRequest(int id, CancellationToken cancellation);
        public Task<Result.Result> RejectRequest(int id, CancellationToken cancellation);

    }
}
