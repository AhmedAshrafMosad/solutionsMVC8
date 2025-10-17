using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetStudentWithDetailsAsync(int id);
        Task<IEnumerable<Student>> GetStudentsWithDepartmentAsync();
        Task<StudentListViewModel> GetPagedStudentsAsync(int page = 1, int pageSize = 10, string searchName = "", int? departmentId = null);
        Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(int departmentId);
        Task<StudentCourseResultViewModel> GetStudentCourseResultAsync(int studentId, int courseId);
    }
}