using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGVRestaurantProject.Models
{
    public partial class Sitting
    {
        public Sitting()
        {
            Bookings = new HashSet<Booking>();
            RestaurantSittings = new HashSet<RestaurantSitting>();
        }
        
        public int SittingId { get; set; }
        public string SittingType { get; set; } = null!;
        public int SittingStart { get; set; }
        public int SittingEnd { get; set; }
        public string SittingDuration
        {
            get
            {
                return SittingStart + " - " + SittingEnd;
            }
        }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<RestaurantSitting> RestaurantSittings { get; set; }
    }
}
