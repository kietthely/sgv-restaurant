using SGVRestaurantProject.Models.Users;
using System;
using System.Collections.Generic;

namespace SGVRestaurantProject.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int SittingId { get; set; }
        public string? DefaultUserId { get; set; }
        public int RestaurantId { get; set; }
        public int BanquetMenuID{ get; set; }
        public int NumberOfGuests { get; set; }
        public string? BookingDate { get; set; }
        public string? Completed{ get; set; }
        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual Sitting Sitting { get; set; } = null!;
        public virtual DefaultUser User { get; set; } = null!;
        public virtual BanquetMenu BanquetMenu{ get; set; } = null!;
    }
}
