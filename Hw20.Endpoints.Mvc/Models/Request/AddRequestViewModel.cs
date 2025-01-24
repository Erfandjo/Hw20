using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hw20.Endpoints.Mvc.Models.Request
{
    public class AddRequestViewModel
    {
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Entering a contact number is mandatory.")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Please enter a valid phone number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Display(Name = "National Code")]
        [Required(ErrorMessage = "Entering the national code is mandatory.")]
        [StringLength(10 , MinimumLength = 10 , ErrorMessage = "The national code must be 10 digits.")]
        public string NationalCode { get; set; }


        [Required(ErrorMessage = "Entering an address is mandatory.")]
        [StringLength(50 , ErrorMessage = "The address can be a maximum of 50 characters.")]
        public string Address { get; set; }


        [Display(Name = "Car Model")]
        [Required(ErrorMessage = "Entering an Car Model is mandatory.")]
        public string CarModel { get; set; }


        [Display(Name = "License Plate")]
        [Required(ErrorMessage = "Entering an License Plate is mandatory.")]
        public string LicensePlate { get; set; }


        [Display(Name = "Year Of Car")]
        [Required(ErrorMessage = "Entering an Year Of Car is mandatory.")]
        [Range(1886 , 2025 , ErrorMessage = "The year of manufacture of the car must be between 1886 and 2025.")]
        [Column(TypeName = "int")]
        public int YearOfCar { get; set; }


        [Display(Name = "Date Visit")]
        [Required(ErrorMessage = "Entering an Date Visit is mandatory.")]
        [DataType(DataType.Date)]
        public DateOnly DateVisit { get; set; }
    }
}
