using App.Domain.Core.Hw20.Car.Entities;

namespace App.Domain.Core.Hw20.Car.Data
{
    public interface ICarRepository
    {
      public Car.Entities.Car GetByLicensePlate(string licensePlate);
    }
}
