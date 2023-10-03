using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Models
{
    public class Achievements
    {
        public int AchievementId { get; set; }
        public string AchievementName{ get; set; }

        public virtual ICollection< DefaultUser> User { get; set; } = null!;
        public virtual ICollection<UserAchievements> UserAchievements { get; set; } = null!;
    }
}
