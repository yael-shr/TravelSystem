using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.Entities;
using TravelSystem.Repositories.Interfaces;
using TravelSystem.Services.Data;

namespace TravelSystem.Services.Repository
{
    public class TeacherRepository(TravelDbContext repo) : ITeacherRepository
    {
        public async Task AddTeacherAsync(Teacher teacher)
        {
            await repo.Teachers.AddAsync(teacher);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await repo.Teachers.ToListAsync();
        }
        public async Task<Teacher> GetByIdAsync(string id)
        {
            return await repo.Teachers.FirstOrDefaultAsync(s => s.PersonalId == id);
        }

       
    }
}
