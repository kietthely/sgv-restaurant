using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SGVRestaurantProject.Models.Users
{
    public class DefaultUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]   
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
