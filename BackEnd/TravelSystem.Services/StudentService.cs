using TravelSystem.Entities.Interfaces;
using TravelSystem.Entities;
using TravelSystem.Repositories.Interfaces;

namespace TravelSystem.Services
{
    public class StudentService(IStudentRepository repo) : IStudentService
    {
        public async Task<IEnumerable<Student>> GetAllStudentsAsync() => await repo.GetAllAsync();

        public async Task<Student> GetStudentByIdAsync(string id) => await repo.GetByIdAsync(id);

        public async Task<IEnumerable<Student>> GetStudentsByGroupAsync(string group) => await repo.GetByClassAsync(group);

        public async Task AddStudentAsync(Student student)
        {
            // כאן אפשר להוסיף לוגיקה עסקית (למשל: בדיקת גיל, תקינות ת"ז וכו')
            await repo.AddStudentAsync(student);
        }
    }
}