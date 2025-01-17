namespace Hw20.Endpoints.Mvc.Models.Request
{
    public class AddRequestViewModel
    {
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public string CarModel { get; set; }
        public string LicensePlate { get; set; }
        public int YearOfCar { get; set; }
        public DateOnly DateVisit { get; set; }
    }
}
