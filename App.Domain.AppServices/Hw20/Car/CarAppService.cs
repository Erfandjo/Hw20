using App.Domain.Core.Hw20.Car.AppService;
using App.Domain.Core.Hw20.Car.Service;

namespace App.Domain.AppServices.Hw20.Car
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarService _carService;

        public CarAppService(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<Core.Hw20.Car.Entities.Car> GetByLicensePlate(string licensePlate, CancellationToken cancellation)
        {
           return await _carService.GetByLicensePlate(licensePlate , cancellation);
        }
    }
}
