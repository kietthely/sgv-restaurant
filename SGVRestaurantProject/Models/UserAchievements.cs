using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Models
{
    public class UserAchievements
    {
        public int UserAchievementsId { get; set; }
        public string? UserId { get; set; }
        public int AchievementId { get; set; }

        public virtual Achievements Achievements{ get; set; } = null!;
        public virtual DefaultUser User { get; set; } = null!;
    }
}
