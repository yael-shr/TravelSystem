using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelSystem.Entities.Interfaces
{
  
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task<IEnumerable<Student>> GetStudentsByGroupAsync(string group);
        Task AddStudentAsync(Student student);
    }
  
}
