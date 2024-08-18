namespace TravelDesk.Models
{
    public class TransportDetail
    {
        public int Id { get; set; }

        public Request? Request { get; set; }
        public int RequestId { get; set; }
        public Boolean InternationalTrvel { get; set; }
        public Boolean DomesticTravel { get; set; }
        public DateTime TravelDateFrom { get; set; }
        public DateTime TravelDateTo { get; set; }
        public virtual CommonTypeRef? TravelFrom { get; set; }
        public int TravelFromId { get; set; }
        public CommonTypeRef? TravelTo { get; set; }
        public int TravelToId { get; set; }
        public string? VisaNumber { get; set; }
        public string? PassportNumber { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Boolean IsActive { get; set; } = true;
    }
}
