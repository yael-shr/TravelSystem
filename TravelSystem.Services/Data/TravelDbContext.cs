using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Core.Entities;
using static TravelSystem.Core.Entities.StudentLocation;

namespace TravelSystem.Services.Data
{
    public class TravelDbContext: DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentLocation> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentLocation>().OwnsOne(sl => sl.Coordinates, conf =>
            {
                conf.OwnsOne(c => c.Longitude);
                conf.OwnsOne(c => c.Latitude);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
