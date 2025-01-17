namespace App.Domain.Core.Hw20.Car.AppService
{
    public interface ICarAppService
    {
        public Car.Entities.Car GetByLicensePlate(string licensePlate);
    }
}
