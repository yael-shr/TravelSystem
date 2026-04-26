using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.Core.Entities
{

        public class Location
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public string PersonalId  { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public DateTimeOffset Timestamp { get; set; }
        }
    }


