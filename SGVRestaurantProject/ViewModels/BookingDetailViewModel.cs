using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGVRestaurantProject.ViewModels
{
    public class BookingDetailViewModel
    {
        public SelectList SittingTimes { get; set; }
        public SelectList Banquets { get; set; }

    }
}
