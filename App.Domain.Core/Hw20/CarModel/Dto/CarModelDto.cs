using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Hw20.CarModel
{
    public class CarModelDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
