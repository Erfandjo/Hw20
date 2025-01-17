namespace App.Domain.Core.Hw20.Car.Service
{
    public interface ICarService
    {
        public Car.Entities.Car GetByLicensePlate(string licensePlate);
    }
}
