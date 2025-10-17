namespace SchoolManagement.ViewModels
{
    public class CustomRouteViewModel
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? Id { get; set; }
        public string SearchTerm { get; set; }
        public int? DepartmentId { get; set; }
        public int Page { get; set; } = 1;
    }

    public class CourseResultViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }
        public string Color { get; set; }
    }
}