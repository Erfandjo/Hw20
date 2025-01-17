using App.Domain.Core.Hw20.Car.Entities;
using App.Domain.Core.Hw20.Request.Enum;
using App.Domain.Core.Hw20.User.Entities;

namespace App.Domain.Core.Hw20.Request.Entities
{
    public class Request
    {
        public int Id { get; set; }
        public User.Entities.User User { get; set; }
        public int UserId { get; set; }
        public Car.Entities.Car Car { get; set; }
        public int CarId { get; set; }
        public DateTime RequestAt { get; set; }
        public DateOnly DateVisit { get; set; }
        public StatusRequestEnum StatusRequest { get; set; }
    }
}
