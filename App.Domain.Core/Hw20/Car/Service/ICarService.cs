namespace App.Domain.Core.Hw20.Car.Service
{
    public interface ICarService
    {
        public Task<Car.Entities.Car> GetByLicensePlate(string licensePlate , CancellationToken cancellationToken);
    }
}
