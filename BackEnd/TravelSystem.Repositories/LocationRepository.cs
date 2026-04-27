using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Entities;
using TravelSystem.Repositories.Interfaces;
using TravelSystem.Services.Data;

namespace TravelSystem.Services.Repository
{
    public class LocationRepository(TravelDbContext repo) : ILocationRepository
    {
     
        public async Task UpsertLocationAsync(Location newLocation)
        {
            var existingLocation = await repo.Locations
                .FirstOrDefaultAsync(l => l.PersonalId == newLocation.PersonalId);

            if (existingLocation != null)
            {
                existingLocation.Latitude = newLocation.Latitude;
                existingLocation.Longitude = newLocation.Longitude;
                existingLocation.Timestamp = newLocation.Timestamp;
            }
            else
            {
                await repo.Locations.AddAsync(newLocation);
            }

            await repo.SaveChangesAsync();
        }

        public async Task<Location> GetLocationAsync(string PersonalId)
        {
           var l= await repo.Locations.Where(l => l.PersonalId == PersonalId)
            .OrderByDescending(l => l.Timestamp) 
            .FirstOrDefaultAsync();
             return l;
        }

        public async Task<List<Location>> GetAllLocation(List<Student> students)
        {
            var studentIds = students.Select(s => s.PersonalId).ToList();

            return await repo.Locations
                .Where(l => studentIds.Contains(l.PersonalId))
                .ToListAsync();
        }
    }
}
