namespace SGVRestaurantProject.Models.ViewModel
{
    public class RestaurantBookingsVM
    {
        public Restaurant theRestaurant { get; set; }
        public List<Booking> restaurantBookings { get; set; }
    }
}
