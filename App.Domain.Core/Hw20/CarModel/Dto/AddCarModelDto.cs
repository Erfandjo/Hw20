using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Hw20.CarModel.Dto
{
    public class AddCarModelDto
    {
        [Required(ErrorMessage = "Entering the Number is mandatory.")]
        [StringLength(10, ErrorMessage = "The Name can be a maximum of 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Entering the Company Id is mandatory.")]
        [Column(TypeName = "int")]
        public int CompanyId { get; set; }
    }
}
