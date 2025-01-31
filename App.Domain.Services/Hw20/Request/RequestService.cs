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

        public async Task<Result> AcceptRequest(int id , CancellationToken cancellation)
        {
           return await _requestRepository.AcceptRequest(id , cancellation);
        }

        public async Task<Result> Add(Core.Hw20.Request.Entities.Request request, CancellationToken cancellation)
        {
            return await _requestRepository.Add(request , cancellation);
        }

        public async Task<int> CountRequestOfDay(DateOnly d, CancellationToken cancellation)
        {
            return await _requestRepository.CountRequestOfDay(d, cancellation);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetAccept(CancellationToken cancellation)
        {
           return await _requestRepository.GetAccept(cancellation);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetAll(CancellationToken cancellation)
        {
           return await _requestRepository.GetAll(cancellation);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetByDate(DateOnly date, CancellationToken cancellation)
        {
            return await _requestRepository.GetByDate(date, cancellation    );
        }

        public async Task<Core.Hw20.Request.Entities.Request> GetLastRequestForCar(int carId, CancellationToken cancellation)
        {
            return await _requestRepository.GetLastRequestForCar(carId, cancellation    );
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetPending(CancellationToken cancellation)
        {
            return await _requestRepository.GetPending(cancellation);
        }

        public async Task<List<Core.Hw20.Request.Entities.Request>> GetReject(CancellationToken cancellation)
        {
            return await _requestRepository.GetReject(cancellation);
        }

        public async Task<Result> RejectRequest(int id, CancellationToken cancellation)
        {
            return await _requestRepository.RejectRequest(id    , cancellation);
        }
    }
}
