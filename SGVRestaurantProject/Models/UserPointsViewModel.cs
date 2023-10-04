using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Models
{
    public class UserPointsViewModel
    {
        public string userId { get; set; }
        public int NumberOfPoints { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
