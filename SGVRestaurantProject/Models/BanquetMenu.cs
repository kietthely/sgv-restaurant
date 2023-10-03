using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class BanquetMenu
    {
        public BanquetMenu()
        {
            BanquetAndMenuItems = new HashSet<BanquetAndMenuItem>();
            RestaurantBanquetMenus = new HashSet<RestaurantBanquetMenu>();
        }

        public int BanquetId { get; set; }
        public string BanquetName { get; set; } = null!;
        public int RestaurantId { get; set; }
        public int? BanquetCost { get; set; }
        public bool BanquetAvailability { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<BanquetAndMenuItem> BanquetAndMenuItems { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RestaurantBanquetMenu> RestaurantBanquetMenus { get; set; }
    }
}
