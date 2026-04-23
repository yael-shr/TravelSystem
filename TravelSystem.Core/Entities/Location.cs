using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.Core.Entities
{

        public record CoordinateDetail
        {
            public string Degrees { get; init; }
            public string Minutes { get; init; }
            public string Seconds { get; init; }
        }

        public record GeoCoordinates
        {
            public CoordinateDetail Longitude { get; init; }
            public CoordinateDetail Latitude { get; init; }
        }

        public class StudentLocation
        {
            [Key]
            public int Id { get; set; }
            public string StudentId { get; set; }
            public GeoCoordinates Coordinates { get; set; }
            public DateTimeOffset Timestamp { get; set; }
        }
    }


