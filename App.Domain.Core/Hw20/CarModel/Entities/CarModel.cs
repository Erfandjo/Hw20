using App.Domain.Core.Hw20.Company.Entities;

namespace App.Domain.Core.Hw20.CarModel.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company.Entities.Company Company { get; set; }

    }
}
