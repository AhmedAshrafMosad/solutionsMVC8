using System.ComponentModel.DataAnnotations;  // إضافة هذا السطر
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Models
{
    public class StuCrsRes
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string Grade { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}