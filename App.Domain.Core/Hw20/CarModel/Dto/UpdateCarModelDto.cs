using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Hw20.CarModel.Dto
{
    public class UpdateCarModelDto
    {
        [Required(ErrorMessage = "Entering the Id is mandatory.")]
        [Column(TypeName = "int")]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Entering the Name is mandatory.")]
        [StringLength(10, ErrorMessage = "The Name can be a maximum of 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Entering the Company Id is mandatory.")]
        [Column(TypeName = "int")]
        public int CompanyId { get; set; }
    }
}
