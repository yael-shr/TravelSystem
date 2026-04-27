using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Entities;

namespace TravelSystem.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetByIdAsync(string id);
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task AddTeacherAsync(Teacher teacher);
    }
}
