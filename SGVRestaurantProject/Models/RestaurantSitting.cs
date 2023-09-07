using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class RestaurantSitting
    {
        public int RestaurantSittingsId { get; set; }
        public int RestaurantId { get; set; }
        public int SittingId { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual Sitting Sitting { get; set; } = null!;
    }
}
