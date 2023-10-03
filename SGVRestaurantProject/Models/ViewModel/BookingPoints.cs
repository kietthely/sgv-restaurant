using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Models.ViewModel
{
    public class BookingPoints
    {
        public List<Booking>? BookingDetails { get; set; }
        public int? Points { get; set; }
        public int? NumberOfBookings { get; set;}

    }
}
