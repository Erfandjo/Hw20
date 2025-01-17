namespace App.Domain.Core.Hw20.Company.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarModel.Entities.CarModel> CarModels { get; set; }
    }
}
