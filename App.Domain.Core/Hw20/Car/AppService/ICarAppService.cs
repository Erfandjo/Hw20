namespace App.Domain.Core.Hw20.Car.AppService
{
    public interface ICarAppService
    {
        public Task<Car.Entities.Car> GetByLicensePlate(string licensePlate , CancellationToken cancellation);
    }
}
