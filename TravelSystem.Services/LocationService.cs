using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Core.DTOs;
using TravelSystem.Core.Entities;
using static TravelSystem.Core.DTOs.LocationUpdateDTO;

namespace TravelSystem.Services
{
    public class LocationService
    {
        public Location MapToEntity(StudentLocationUpdateDTO lu)
        {
          double  Latitude = double.Parse(lu.GeoCoordinates.Latitude.Degrees )+ double.Parse(lu.GeoCoordinates.Latitude.Minutes) /60 + double.Parse(lu.GeoCoordinates.Latitude.Seconds)/ 3600;
          double Longitude = double.Parse(lu.GeoCoordinates.Longitude.Degrees )+ double.Parse(lu.GeoCoordinates.Longitude.Minutes )/60 + double.Parse(lu.GeoCoordinates.Longitude.Seconds)/ 3600;
          Location location = new Location();
          location.Latitude = Latitude;
          location.Longitude = Longitude;
          location.Timestamp = DateTime.Now;
          location.PersonalId = lu.Id;
          return location;
        }
    }
}
