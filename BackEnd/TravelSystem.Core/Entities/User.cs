using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.Entities
{
    public class User
    {
       public int Id { get; set; }
      
       [Required]
       [StringLength(9)]
       public string PersonalId { get; set; } 
      
       [Required]
       public string FirstName { get; set; }
      
       [Required]
       public string LastName { get; set; }
      
       [Required]
       public string ClassGroup { get; set; }
      
       [Required]
       public string Username { get; set; }
      
       [Required]
       public string PasswordHash { get; set; } 
      
    }
}
