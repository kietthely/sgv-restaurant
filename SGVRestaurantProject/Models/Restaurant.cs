namespace SGVRestaurantProject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            BanquetMenus = new HashSet<BanquetMenu>();
            Bookings = new HashSet<Booking>();
            RestaurantBanquetMenus = new HashSet<RestaurantBanquetMenu>();
            RestaurantSittings = new HashSet<RestaurantSitting>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantAddress { get; set; } = null!;
        public string RestaurantName { get; set; } = null!;
        public string RestaurantEmail { get; set; } = null!;
        public string RestaurantPhoneNumber { get; set; } = null!;
        public virtual ICollection<BanquetMenu> BanquetMenus { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RestaurantBanquetMenu> RestaurantBanquetMenus { get; set; }
        public virtual ICollection<RestaurantSitting> RestaurantSittings { get; set; }
    }
}
