using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Core.Entities;

namespace TravelSystem.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(string id);
        Task<IEnumerable<Student>> GetAllAsync();
        Task AddStudentAsync(Student student);
        Task<IEnumerable<Student>> GetByClassAsync(string classGroup);
    }
}
