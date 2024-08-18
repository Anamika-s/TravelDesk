using Microsoft.EntityFrameworkCore;
using TravelDesk.Models;
namespace TravelDesk.Context
{
    public class TravelDeskDbContext : DbContext
    {
        public TravelDeskDbContext()
        {
            
        }
        public TravelDeskDbContext(DbContextOptions<TravelDeskDbContext> options) :base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommonTypeRef> CommonTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<HotelDetail> HotelDetails { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<TransportDetail> TransportDetails { get; set; }



    }


}

