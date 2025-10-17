using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public CourseService(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<CourseListViewModel> GetCoursesAsync(int page = 1, string searchName = "", int? departmentId = null)
        {
            return await _courseRepository.GetPagedCoursesAsync(page, 10, searchName, departmentId);
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseWithDetailsAsync(id);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            await _courseRepository.AddAsync(course);
            await _courseRepository.SaveAsync(); // استخدام SaveAsync
            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            _courseRepository.Update(course);
            await _courseRepository.SaveAsync(); // استخدام SaveAsync
            return course;
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                _courseRepository.Remove(course);
                await _courseRepository.SaveAsync(); // استخدام SaveAsync
            }
        }

        public async Task<bool> CourseExistsAsync(int id)
        {
            return await _courseRepository.ExistsAsync(c => c.Id == id);
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return departments.ToList();
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.ToList();
        }
    }
}