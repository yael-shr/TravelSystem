using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Core.Entities;
using TravelSystem.Core.Interfaces;
using TravelSystem.Services.Data;

namespace TravelSystem.Services
{
    public class LocationRepository(TravelDbContext repo) : ILocationRepository
    {
        public async Task<Location> AddLocationAsync(Location location)
        {
            await repo.Locations.AddAsync(location);
            await repo.SaveChangesAsync();
            return location;
        }

        public async Task<Location> GetLocationAsync(string PersonalId)
        {
           var l= await repo.Locations.Where(l => l.PersonalId == PersonalId)
            .OrderByDescending(l => l.Timestamp) 
            .FirstOrDefaultAsync();
             return l;
        }
    }
}
