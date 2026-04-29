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
            var students = await repo.GetByIdAsync(student.PersonalId);
            if (students == null)
            {
                await repo.AddStudentAsync(student);
            }
            else {

            }
        }
    }
}