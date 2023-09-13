namespace SGVRestaurantProject.Models
{
    public partial class UserAccount
    {
        //public UserAccount()
        //{
        //    Bookings = new HashSet<Booking>();
        //}

        public int UserId { get; set; }
        public string UserType { get; set; } = null!;
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }

        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}
