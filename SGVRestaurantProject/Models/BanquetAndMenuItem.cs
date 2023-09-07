using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class BanquetAndMenuItem
    {
        public int BanquetAndMenuItemsId { get; set; }
        public int ItemId { get; set; }
        public int BanquetId { get; set; }

        public virtual BanquetMenu Banquet { get; set; } = null!;
        public virtual MenuItem Item { get; set; } = null!;
    }
}
