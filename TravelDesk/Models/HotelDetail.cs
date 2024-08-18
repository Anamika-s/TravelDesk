using Azure.Core;

namespace TravelDesk.Models
{
    public class HotelDetail
    {
        public int Id { get; set; }
        public Request? Request { get; set; }
        public int RequestId { get; set; }
        public DateTime StayDateFrom { get; set; }
        public DateTime StayDateTo { get; set; }
        public virtual CommonTypeRef? MealPreference { get; set; }
        public int MealPreferenceId { get; set; }
        public virtual CommonTypeRef? NoOfMeals { get; set; }
        public int NoOfMealsId { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Boolean IsActive { get; set; } = true;
    }
}
