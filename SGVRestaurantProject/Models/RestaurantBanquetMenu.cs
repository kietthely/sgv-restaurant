using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class RestaurantBanquetMenu
    {
        public int RestaurantBanquetMenuId { get; set; }
        public int RestaurantId { get; set; }
        public int BanquetId { get; set; }

        public virtual BanquetMenu Banquet { get; set; } = null!;
        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}
