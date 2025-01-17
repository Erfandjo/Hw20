using App.Domain.Core.Hw20.CarModel.Entities;
using App.Domain.Core.Hw20.Company.Entities;

namespace Hw20.Endpoints.Mvc.Models.Admin
{
    public class UpdateCarModelViewModel
    {
        public CarModel CarModel { get; set; }
        public List<Company> Companies { get; set; }
    }
}
