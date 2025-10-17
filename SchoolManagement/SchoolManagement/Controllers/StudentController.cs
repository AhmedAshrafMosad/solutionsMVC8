using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Models;
using SchoolManagement.Services;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public StudentController(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        // ✅ عرض كل الطلاب مع بحث وتصفية وصفحات
        [HttpGet]
        public async Task<IActionResult> GetAll(string? searchName, int? departmentId, int page = 1)
        {
            var studentsPaged = await _studentService.GetStudentsAsync(page, searchName ?? "", departmentId);
            var departments = await _departmentService.GetAllDepartmentsAsync();

            studentsPaged.Departments = departments
                .Select(d => new Department { Id = d.Id, Name = d.Name })
                .ToList();

            return View(studentsPaged);
        }

        // ✅ عرض تفاصيل طالب محدد - CHANGED: Details → GetById
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        // ✅ صفحة إضافة طالب
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Student model)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");
                return View(model);
            }

            await _studentService.CreateStudentAsync(model);
            TempData["Success"] = "Student added successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ تعديل طالب
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            var departments = await _departmentService.GetAllDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", student.DepartmentId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student model)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.GetAllDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", model.DepartmentId);
                return View(model);
            }

            await _studentService.UpdateStudentAsync(model);
            TempData["Success"] = "Student updated successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ حذف طالب
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            TempData["Success"] = "Student deleted successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ عرض نتيجة الطالب في كورس معين
        [HttpGet]
        public async Task<IActionResult> CourseResult(int studentId, int courseId)
        {
            var result = await _studentService.GetStudentCourseResultAsync(studentId, courseId);
            if (result == null)
                return NotFound();

            return View(result);
        }
    }
}