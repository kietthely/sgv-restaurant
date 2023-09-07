using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            BanquetAndMenuItems = new HashSet<BanquetAndMenuItem>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;

        public virtual ICollection<BanquetAndMenuItem> BanquetAndMenuItems { get; set; }
    }
}
