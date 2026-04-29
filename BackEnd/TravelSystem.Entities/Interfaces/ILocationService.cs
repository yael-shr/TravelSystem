
using TravelSystem.DTOs;
using static TravelSystem.DTOs.LocationUpdateDTO;

namespace TravelSystem.Entities.Interfaces
{
    public interface ILocationService
    {
        Task<Location> GetLocationByIdAsync(string id);
        Task UpdateLocationAsync(StudentLocationUpdateDTO dto);
        Task<List<Location>> GetAllLocationsAsync(List<Student> students);

    }
}
