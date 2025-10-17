using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>());

            // Check if database exists and has data
            context.Database.EnsureCreated();

            if (context.Departments.Any())
            {
                return; // Database already seeded
            }

            // Add Departments
            var departments = new Department[]
            {
                new Department { Name = "Computer Science", MgrName = "Dr. Ahmed Ali" },
                new Department { Name = "Mathematics", MgrName = "Dr. Sara Mohamed" },
                new Department { Name = "Physics", MgrName = "Dr. Omar Hassan" },
                new Department { Name = "Business Administration", MgrName = "Dr. Layla Ahmed" },
                new Department { Name = "Engineering", MgrName = "Dr. Michael Brown" }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            // Add Students with age diversity
            var students = new Student[]
            {
                // Computer Science Department (ID = 1) - Will have more than 50 students (Main)
                new Student { Name = "John Smith", Age = 22, DepartmentId = 1 },
                new Student { Name = "Emily Johnson", Age = 26, DepartmentId = 1 },
                new Student { Name = "Michael Brown", Age = 28, DepartmentId = 1 },
                new Student { Name = "Sarah Davis", Age = 24, DepartmentId = 1 },
                new Student { Name = "David Wilson", Age = 30, DepartmentId = 1 },
                new Student { Name = "Jennifer Miller", Age = 23, DepartmentId = 1 },
                new Student { Name = "James Taylor", Age = 27, DepartmentId = 1 },
                new Student { Name = "Lisa Anderson", Age = 29, DepartmentId = 1 },
                new Student { Name = "Robert Thomas", Age = 31, DepartmentId = 1 },
                new Student { Name = "Mary Jackson", Age = 25, DepartmentId = 1 },
                new Student { Name = "William White", Age = 26, DepartmentId = 1 },
                new Student { Name = "Linda Harris", Age = 28, DepartmentId = 1 },
                new Student { Name = "Richard Martin", Age = 22, DepartmentId = 1 },
                new Student { Name = "Patricia Thompson", Age = 30, DepartmentId = 1 },
                new Student { Name = "Charles Garcia", Age = 27, DepartmentId = 1 },
                new Student { Name = "Barbara Martinez", Age = 24, DepartmentId = 1 },
                new Student { Name = "Joseph Robinson", Age = 29, DepartmentId = 1 },
                new Student { Name = "Susan Clark", Age = 26, DepartmentId = 1 },
                new Student { Name = "Thomas Rodriguez", Age = 31, DepartmentId = 1 },
                new Student { Name = "Jessica Lewis", Age = 25, DepartmentId = 1 },
                new Student { Name = "Christopher Lee", Age = 28, DepartmentId = 1 },
                new Student { Name = "Karen Walker", Age = 23, DepartmentId = 1 },
                new Student { Name = "Daniel Hall", Age = 27, DepartmentId = 1 },
                new Student { Name = "Nancy Allen", Age = 30, DepartmentId = 1 },
                new Student { Name = "Paul Young", Age = 26, DepartmentId = 1 },
                new Student { Name = "Betty King", Age = 24, DepartmentId = 1 },
                new Student { Name = "Mark Wright", Age = 29, DepartmentId = 1 },
                new Student { Name = "Donna Scott", Age = 31, DepartmentId = 1 },
                new Student { Name = "George Green", Age = 25, DepartmentId = 1 },
                new Student { Name = "Dorothy Adams", Age = 28, DepartmentId = 1 },
                new Student { Name = "Kenneth Baker", Age = 22, DepartmentId = 1 },
                new Student { Name = "Sandra Gonzalez", Age = 27, DepartmentId = 1 },
                new Student { Name = "Steven Nelson", Age = 30, DepartmentId = 1 },
                new Student { Name = "Carol Carter", Age = 26, DepartmentId = 1 },
                new Student { Name = "Edward Mitchell", Age = 24, DepartmentId = 1 },
                new Student { Name = "Ruth Perez", Age = 29, DepartmentId = 1 },
                new Student { Name = "Brian Roberts", Age = 31, DepartmentId = 1 },
                new Student { Name = "Sharon Turner", Age = 25, DepartmentId = 1 },
                new Student { Name = "Ronald Phillips", Age = 28, DepartmentId = 1 },
                new Student { Name = "Michelle Campbell", Age = 27, DepartmentId = 1 },
                new Student { Name = "Jason Parker", Age = 23, DepartmentId = 1 },
                new Student { Name = "Laura Evans", Age = 30, DepartmentId = 1 },
                new Student { Name = "Kevin Edwards", Age = 26, DepartmentId = 1 },
                new Student { Name = "Sarah Collins", Age = 29, DepartmentId = 1 },
                new Student { Name = "Timothy Stewart", Age = 24, DepartmentId = 1 },
                new Student { Name = "Deborah Sanchez", Age = 31, DepartmentId = 1 },
                new Student { Name = "Jeffrey Morris", Age = 27, DepartmentId = 1 },
                new Student { Name = "Lisa Rogers", Age = 25, DepartmentId = 1 },
                new Student { Name = "Ryan Reed", Age = 28, DepartmentId = 1 },
                new Student { Name = "Nancy Cook", Age = 30, DepartmentId = 1 },
                new Student { Name = "Gary Morgan", Age = 26, DepartmentId = 1 },
                new Student { Name = "Karen Bell", Age = 22, DepartmentId = 1 },
                new Student { Name = "Jacob Murphy", Age = 29, DepartmentId = 1 },
                new Student { Name = "Donna Bailey", Age = 31, DepartmentId = 1 },

                // Mathematics Department (ID = 2) - Branch (less than 50)
                new Student { Name = "Alexander Rivera", Age = 23, DepartmentId = 2 },
                new Student { Name = "Emma Cooper", Age = 27, DepartmentId = 2 },
                new Student { Name = "Henry Richardson", Age = 25, DepartmentId = 2 },
                new Student { Name = "Olivia Cox", Age = 29, DepartmentId = 2 },
                new Student { Name = "Noah Howard", Age = 26, DepartmentId = 2 },
                new Student { Name = "Sophia Ward", Age = 28, DepartmentId = 2 },
                new Student { Name = "Lucas Torres", Age = 30, DepartmentId = 2 },
                new Student { Name = "Ava Peterson", Age = 24, DepartmentId = 2 },
                new Student { Name = "Ethan Gray", Age = 31, DepartmentId = 2 },
                new Student { Name = "Isabella Ramirez", Age = 27, DepartmentId = 2 },
                new Student { Name = "Mason James", Age = 22, DepartmentId = 2 },
                new Student { Name = "Mia Watson", Age = 26, DepartmentId = 2 },
                new Student { Name = "Logan Brooks", Age = 29, DepartmentId = 2 },
                new Student { Name = "Charlotte Kelly", Age = 25, DepartmentId = 2 },
                new Student { Name = "Caleb Sanders", Age = 28, DepartmentId = 2 },

                // Physics Department (ID = 3) - Branch
                new Student { Name = "Benjamin Price", Age = 21, DepartmentId = 3 },
                new Student { Name = "Amelia Bennett", Age = 26, DepartmentId = 3 },
                new Student { Name = "Samuel Wood", Age = 31, DepartmentId = 3 },
                new Student { Name = "Harper Barnes", Age = 28, DepartmentId = 3 },
                new Student { Name = "Jackson Ross", Age = 24, DepartmentId = 3 },
                new Student { Name = "Evelyn Henderson", Age = 30, DepartmentId = 3 },
                new Student { Name = "Aiden Coleman", Age = 27, DepartmentId = 3 },
                new Student { Name = "Abigail Jenkins", Age = 29, DepartmentId = 3 },
                new Student { Name = "Luke Perry", Age = 26, DepartmentId = 3 },
                new Student { Name = "Ella Powell", Age = 31, DepartmentId = 3 },

                // Business Administration (ID = 4) - Branch
                new Student { Name = "Daniel Long", Age = 23, DepartmentId = 4 },
                new Student { Name = "Scarlett Patterson", Age = 27, DepartmentId = 4 },
                new Student { Name = "Jack Hughes", Age = 30, DepartmentId = 4 },
                new Student { Name = "Lily Flores", Age = 25, DepartmentId = 4 },
                new Student { Name = "Owen Washington", Age = 28, DepartmentId = 4 },
                new Student { Name = "Chloe Butler", Age = 26, DepartmentId = 4 },
                new Student { Name = "Gabriel Simmons", Age = 31, DepartmentId = 4 },
                new Student { Name = "Zoey Foster", Age = 29, DepartmentId = 4 },

                // Engineering Department (ID = 5) - Branch
                new Student { Name = "Julian Gonzales", Age = 24, DepartmentId = 5 },
                new Student { Name = "Penelope Bryant", Age = 28, DepartmentId = 5 },
                new Student { Name = "Levi Alexander", Age = 26, DepartmentId = 5 },
                new Student { Name = "Lillian Russell", Age = 30, DepartmentId = 5 },
                new Student { Name = "Isaiah Griffin", Age = 25, DepartmentId = 5 },
                new Student { Name = "Hannah Diaz", Age = 27, DepartmentId = 5 }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            // Add Teachers
            var teachers = new Teacher[]
            {
                new Teacher { Name = "Dr. Robert Chen", Salary = "75000", Address = "123 University Ave", CoursId = "CS101", DepartmentId = 1 },
                new Teacher { Name = "Dr. Maria Garcia", Salary = "72000", Address = "456 College St", CoursId = "CS102", DepartmentId = 1 },
                new Teacher { Name = "Dr. James Wilson", Salary = "68000", Address = "789 Campus Rd", CoursId = "MATH201", DepartmentId = 2 },
                new Teacher { Name = "Dr. Patricia Lee", Salary = "71000", Address = "321 Academic Blvd", CoursId = "PHY301", DepartmentId = 3 },
                new Teacher { Name = "Dr. Christopher Kim", Salary = "69000", Address = "654 Education Ln", CoursId = "BUS401", DepartmentId = 4 },
                new Teacher { Name = "Dr. Amanda Scott", Salary = "73000", Address = "987 Learning Way", CoursId = "ENG501", DepartmentId = 5 }
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            // Add Courses
            var courses = new Course[]
            {
                new Course { Name = "Data Structures", Degree = "Bachelor", MgrName = "Dr. Robert Chen", DepartmentId = 1 },
                new Course { Name = "Algorithms", Degree = "Bachelor", MgrName = "Dr. Maria Garcia", DepartmentId = 1 },
                new Course { Name = "Database Systems", Degree = "Master", MgrName = "Dr. Ahmed Ali", DepartmentId = 1 },
                new Course { Name = "Calculus I", Degree = "Bachelor", MgrName = "Dr. James Wilson", DepartmentId = 2 },
                new Course { Name = "Linear Algebra", Degree = "Bachelor", MgrName = "Dr. Sara Mohamed", DepartmentId = 2 },
                new Course { Name = "Quantum Physics", Degree = "Master", MgrName = "Dr. Patricia Lee", DepartmentId = 3 },
                new Course { Name = "Classical Mechanics", Degree = "Bachelor", MgrName = "Dr. Omar Hassan", DepartmentId = 3 },
                new Course { Name = "Marketing Management", Degree = "Bachelor", MgrName = "Dr. Christopher Kim", DepartmentId = 4 },
                new Course { Name = "Financial Accounting", Degree = "Bachelor", MgrName = "Dr. Layla Ahmed", DepartmentId = 4 },
                new Course { Name = "Circuit Analysis", Degree = "Bachelor", MgrName = "Dr. Amanda Scott", DepartmentId = 5 },
                new Course { Name = "Thermodynamics", Degree = "Master", MgrName = "Dr. Michael Brown", DepartmentId = 5 }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            // Add Student Course Results (Enrollments)
            var enrollments = new StuCrsRes[]
            {
                new StuCrsRes { StudentId = 1, CourseId = 1, Grade = "A" },
                new StuCrsRes { StudentId = 2, CourseId = 1, Grade = "B+" },
                new StuCrsRes { StudentId = 3, CourseId = 2, Grade = "A-" },
                new StuCrsRes { StudentId = 4, CourseId = 3, Grade = "B" },
                new StuCrsRes { StudentId = 5, CourseId = 1, Grade = "A" },
                new StuCrsRes { StudentId = 15, CourseId = 4, Grade = "B+" },
                new StuCrsRes { StudentId = 16, CourseId = 4, Grade = "A" },
                new StuCrsRes { StudentId = 25, CourseId = 6, Grade = "A+" },
                new StuCrsRes { StudentId = 26, CourseId = 6, Grade = "B+" },
                new StuCrsRes { StudentId = 35, CourseId = 8, Grade = "A-" },
                new StuCrsRes { StudentId = 36, CourseId = 9, Grade = "B" },
                new StuCrsRes { StudentId = 45, CourseId = 10, Grade = "A" },
                new StuCrsRes { StudentId = 46, CourseId = 11, Grade = "B+" }
            };

            context.StuCrsRes.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}