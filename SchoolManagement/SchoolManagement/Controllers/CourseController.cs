using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagement.Models;
using SchoolManagement.Services;
using SchoolManagement.ViewModels;

namespace SchoolManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _departmentService;

        public CourseController(ICourseService courseService, IDepartmentService departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }

        // ✅ عرض جميع الكورسات مع البحث والتصفية
        public async Task<IActionResult> GetAll(int page = 1, string searchName = "", int? departmentId = null)
        {
            var viewModel = await _courseService.GetCoursesAsync(page, searchName, departmentId);
            viewModel.Departments = await _courseService.GetDepartmentsAsync();
            return View(viewModel);
        }

        // ✅ عرض تفاصيل كورس واحد
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // ✅ إنشاء كورس جديد (عرض الفورم)
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await _courseService.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            return View(new Course());
        }

        // ✅ إنشاء كورس جديد (استقبال البيانات)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Course course)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _courseService.GetDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");
                return View(course);
            }

            await _courseService.CreateCourseAsync(course);
            TempData["Success"] = "Course added successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ تعديل كورس (عرض الفورم)
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();

            var departments = await _courseService.GetDepartmentsAsync();
            ViewBag.Departments = new SelectList(departments, "Id", "Name", course.DepartmentId);
            return View(course);
        }

        // ✅ تعديل كورس (استقبال التعديل)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _courseService.GetDepartmentsAsync();
                ViewBag.Departments = new SelectList(departments, "Id", "Name", course.DepartmentId);
                return View(course);
            }

            await _courseService.UpdateCourseAsync(course);
            TempData["Success"] = "Course updated successfully!";
            return RedirectToAction(nameof(GetAll));
        }

        // ✅ تأكيد الحذف
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // ✅ تنفيذ الحذف
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            TempData["Success"] = "Course deleted successfully!";
            return RedirectToAction(nameof(GetAll));
        }
    }
}