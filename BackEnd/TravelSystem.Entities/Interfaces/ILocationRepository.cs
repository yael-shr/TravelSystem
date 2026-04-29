using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Entities;

namespace TravelSystem.Repositories.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetLocationAsync(string PersonalId);
        public Task UpsertLocationAsync(Location newLocation);
        Task<List<Location>> GetAllLocation(List<Student> students);
    }
}
