namespace SGVRestaurantProject.Models
{
    public class CompleteRestaurantDetails
    {
        public Restaurant theRestaurant { get; set; }
        public List<RestaurantBanquetMenu> banquets { get; set; }
    }
}
