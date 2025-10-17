using SchoolManagement.Models;

namespace SchoolManagement.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<List<Department>> GetAllWithDetailsAsync();
        Task<Department> GetByIdWithDetailsAsync(int id);
        Task<List<Course>> GetAllCoursesAsync();
        Task<List<Student>> GetAllStudentsAsync();
    }
}