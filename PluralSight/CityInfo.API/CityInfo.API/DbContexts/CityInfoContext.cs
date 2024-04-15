using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContext
{
    public class CityInfoContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<PointOfInterest> PointsOfInterests { get; set;}

        public CityInfoContext(DbContextOptions options) : base(options)
        {
            
        }

        // One way to configure db..
        //public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
