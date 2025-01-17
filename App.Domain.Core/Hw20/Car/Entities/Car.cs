namespace App.Domain.Core.Hw20.Car.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public int YearOfCar { get; set; }
        public CarModel.Entities.CarModel CarModel { get; set; }
        public int CarModelId { get; set; }
    }
}
