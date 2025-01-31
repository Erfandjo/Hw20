using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Core.Hw20.Request.Dto
{
    public class AddRequestDto
    {
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Entering a contact number is mandatory.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Please enter a valid phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "National Code")]
        [Required(ErrorMessage = "Entering the national code is mandatory.")]
       // [StringLength(10, MinimumLength = 10, ErrorMessage = "The national code must be 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The national code must be exactly 10 digits and contain only numbers.")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "Entering an address is mandatory.")]
        [StringLength(50, ErrorMessage = "The address can be a maximum of 50 characters.")]
        public string Address { get; set; }

        [Display(Name = "Car Model Id")]
        [Required(ErrorMessage = "Entering an Car Model Id is mandatory.")]
        public int CarModelId { get; set; }

        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "Entering an License Plate is mandatory.")]
        public string LicensePlate { get; set; }

        [Display(Name = "Year Of Car")]
        [Required(ErrorMessage = "Entering an Year Of Car is mandatory.")]
        [Range(1886, 2025, ErrorMessage = "The year of manufacture of the car must be between 1886 and 2025.")]
        [Column(TypeName = "int")]
        public int YearOfCar { get; set; }

        [Display(Name = "Date Visit")]
        [Required(ErrorMessage = "Entering an Date Visit is mandatory.")]
        [DataType(DataType.Date)]
        public  DateOnly DateVisit { get; set; }
    }
}
