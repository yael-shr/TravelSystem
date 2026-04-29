using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelSystem.DTOs;
using TravelSystem.Entities;
using TravelSystem.Entities.Interfaces;
using TravelSystem.Repositories.Interfaces;

namespace TravelSystem.Services
{
    public class TeacherService(ITeacherRepository repo) : ITeacherService
    {
        public async Task AddTeacherAsync(Teacher teacher)
        {
           await repo.AddTeacherAsync(teacher);
        }
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync() => await repo.GetAllAsync();
        public async Task<Teacher> GetTeacherByIdAsync(string id) => await repo.GetByIdAsync(id);

        //public async Task<Teacher> ValidatUser(LoginDTO user)
        //{
        //   var teacher = await repo.GetByIdAsync(user.Id);
        //    if (teacher == null)
        //        return null;


        //}
    }
}
