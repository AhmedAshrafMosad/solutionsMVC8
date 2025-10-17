namespace SchoolManagement.ViewModels
{
    public class StudentCourseResultViewModel
    {
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string Color { get; set; } // "green" or "red"
    }

    public class StudentCourseRequestViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}