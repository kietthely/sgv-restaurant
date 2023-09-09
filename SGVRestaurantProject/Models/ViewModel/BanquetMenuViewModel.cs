namespace SGVRestaurantProject.Models.ViewModel
{
    public class BanquetMenuViewModel
    {
        // Created by Minh. To be used when modifying banquet menu items.
            public int BanquetId { get; set; }
            public string BanquetName { get; set; }
            public int RestaurantId { get; set; }
            public int? BanquetCost { get; set; }
            public bool BanquetAvailability { get; set; }
            public string RestaurantName { get; set; }
            public List<MenuItem> MenuItems { get; set; }
        
    }
}
