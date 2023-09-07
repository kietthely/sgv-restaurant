using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Bookings = new HashSet<Booking>();
            RestaurantBanquetMenus = new HashSet<RestaurantBanquetMenu>();
            RestaurantSittings = new HashSet<RestaurantSitting>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantAddress { get; set; } = null!;
        public string RestaurantName { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RestaurantBanquetMenu> RestaurantBanquetMenus { get; set; }
        public virtual ICollection<RestaurantSitting> RestaurantSittings { get; set; }
    }
}
