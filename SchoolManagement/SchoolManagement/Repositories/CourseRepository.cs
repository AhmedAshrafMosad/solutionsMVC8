using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext context) : base(context) { }

        public async Task<Course> GetCourseWithDetailsAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Department)
                .Include(c => c.StuCrsRes)
                    .ThenInclude(scr => scr.Student)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCoursesWithDepartmentAsync()
        {
            return await _context.Courses
                .Include(c => c.Department)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<CourseListViewModel> GetPagedCoursesAsync(int page = 1, int pageSize = 10, string searchName = "", int? departmentId = null)
        {
            var query = _context.Courses.Include(c => c.Department).AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(c => c.Name.Contains(searchName));
            }

            if (departmentId.HasValue)
            {
                query = query.Where(c => c.DepartmentId == departmentId.Value);
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var courses = await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var departments = await _context.Departments.ToListAsync();

            return new CourseListViewModel
            {
                Courses = courses,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalCount = totalCount,
                SearchName = searchName,
                FilterDepartmentId = departmentId,
                Departments = departments
            };
        }

        public async Task<IEnumerable<Course>> GetCoursesByDepartmentAsync(int departmentId)
        {
            return await _context.Courses
                .Where(c => c.DepartmentId == departmentId)
                .Include(c => c.Department)
                .ToListAsync();
        }
    }
}