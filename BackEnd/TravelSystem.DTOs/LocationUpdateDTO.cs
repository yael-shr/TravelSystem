using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.DTOs
{
    public class LocationUpdateDTO
    {

        public record CoordinateDetail
        {
            public string Degrees { get; init; }
            public string Minutes { get; init; }
            public string Seconds { get; init; }
        }

        public record GeoCoordinates
        {
            public CoordinateDetail? Longitude { get; init; }
            public CoordinateDetail? Latitude { get; init; }
        }

        public class StudentLocationUpdateDTO
        {
            public string Id { get; set; }
            public GeoCoordinates? GeoCoordinates { get; set; }
            public DateTimeOffset Timestamp { get; set; }
        }

    }
}
