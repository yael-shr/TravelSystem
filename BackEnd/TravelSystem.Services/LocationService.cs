using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.DTOs;
using TravelSystem.Entities;
using static TravelSystem.DTOs.LocationUpdateDTO;

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
          location.Timestamp = lu.Timestamp;
          location.PersonalId = lu.Id;
          return location;
        }

        public double CalculateDistance(Location l1 , Location l2)
        {
            const double R = 6371;
            double dLat = ToRadians(l2.Latitude - l1.Latitude);
            double dLon = ToRadians(l2.Longitude - l1.Longitude);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadians(l1.Latitude)) * Math.Cos(ToRadians(l2.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = R * c;

            return distance * 1000;
        }
        private double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
