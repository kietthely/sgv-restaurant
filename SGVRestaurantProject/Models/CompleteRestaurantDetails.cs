namespace SGVRestaurantProject.Models
{
    public class CompleteRestaurantDetails
    {
        public Restaurant theRestaurant { get; set; }
        public List<RestaurantBanquetMenu> banquets { get; set; }
        public List<BanquetMenu> banquetMenus { get; set; }
        public List<BanquetAndMenuItem> bami { get; set; }
        public List<MenuItem> menuItems { get; set; }
    }
}
