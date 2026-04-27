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
    public class StudentRepository(TravelDbContext repo) : IStudentRepository
    {
        public async Task AddStudentAsync(Student student)
        {
            await repo.Students.AddAsync(student);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
          return await repo.Students.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetByClassAsync(string classGroup)
        {
            return await repo.Students.
                Where(s=> s.ClassGroup== classGroup)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await repo.Students.FirstOrDefaultAsync(s => s.PersonalId == id);
        }
    }
}
