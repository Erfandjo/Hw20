using App.Domain.Core.Hw20.Car.Data;
using App.Domain.Core.Hw20.Car.Service;

namespace App.Domain.Services.Hw20.Car
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Core.Hw20.Car.Entities.Car> GetByLicensePlate(string licensePlate , CancellationToken cancellation)
        {
          return await _carRepository.GetByLicensePlate(licensePlate , cancellation);
        }
    }
}
