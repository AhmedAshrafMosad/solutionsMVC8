using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Interfaces;
using SchoolManagement.Models;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context) { }

        public async Task<Student> GetStudentWithDetailsAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StuCrsRes)
                    .ThenInclude(scr => scr.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudentsWithDepartmentAsync()
        {
            return await _context.Students
                .Include(s => s.Department)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<StudentListViewModel> GetPagedStudentsAsync(int page = 1, int pageSize = 10, string searchName = "", int? departmentId = null)
        {
            var query = _context.Students.Include(s => s.Department).AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(s => s.Name.Contains(searchName));
            }

            if (departmentId.HasValue)
            {
                query = query.Where(s => s.DepartmentId == departmentId.Value);
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var students = await query
                .OrderBy(s => s.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var departments = await _context.Departments.ToListAsync();

            return new StudentListViewModel
            {
                Students = students,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize,
                TotalCount = totalCount,
                SearchName = searchName,
                FilterDepartmentId = departmentId,
                Departments = departments
            };
        }

        public async Task<IEnumerable<Student>> GetStudentsByDepartmentAsync(int departmentId)
        {
            return await _context.Students
                .Where(s => s.DepartmentId == departmentId)
                .Include(s => s.Department)
                .ToListAsync();
        }

        public async Task<StudentCourseResultViewModel> GetStudentCourseResultAsync(int studentId, int courseId)
        {
            var result = await _context.StuCrsRes
                .Include(scr => scr.Student)
                .Include(scr => scr.Course)
                .FirstOrDefaultAsync(scr => scr.StudentId == studentId && scr.CourseId == courseId);

            if (result == null) return null;

            var isPassing = IsPassingGrade(result.Grade);

            return new StudentCourseResultViewModel
            {
                StudentName = result.Student.Name,
                CourseName = result.Course.Name,
                Grade = result.Grade,
                Color = isPassing ? "green" : "red"
            };
        }

        private bool IsPassingGrade(string grade)
        {
            if (string.IsNullOrEmpty(grade)) return false;
            var passingGrades = new[] { "A", "B", "C", "D", "A+", "A-", "B+", "B-", "C+", "C-" };
            return passingGrades.Contains(grade.ToUpper());
        }
    }
}