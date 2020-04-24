using Microsoft.EntityFrameworkCore;

namespace LO.MyAirport.EF
{
    public class MyAirportContext : DbContext
    {
         public DbSet<Vol> Vols { get; set; }
        public DbSet<Bagage> Bagages { get; set; }

        public MyAirportContext(DbContextOptions<MyAirportContext> options) : base(options)
        {
        }

        public MyAirportContext()
        {
        }
    }
}
