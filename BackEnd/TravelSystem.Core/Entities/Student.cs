using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.Entities
{
    public class Student
    {
        [Key]
        public string PersonalId { get; set; }
        public string FullName { get; set; }
        public string ClassGroup { get; set; }


    }
}
