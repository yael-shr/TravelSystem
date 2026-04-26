using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Core.DTOs;
using TravelSystem.Core.Entities;

namespace TravelSystem.Core.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetLocationAsync(string PersonalId);
        Task<Location> AddLocationAsync(Location location);
    }
}
