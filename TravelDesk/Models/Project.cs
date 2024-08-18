namespace TravelDesk.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Boolean IsActive { get; set; } = true;
    }
}
