namespace SGVRestaurantProject.Models.ViewModel
{
    public class BanquetMenuItemsViewModel
    {
        public int BanquetAndMenuItemsId { get; set; }
        public int ItemId { get; set; }
        public int BanquetId { get; set; }

        public List<Restaurant> restaurantList { get; set; }

        public virtual BanquetMenu Banquet { get; set; } = null!;
        public virtual MenuItem Item { get; set; } = null!;
    }
}
