using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SchoolManagement.Data
{
    public class SchoolContext : DbContext
    {
        // Constructor for Dependency Injection
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        // Parameterless constructor for Migrations
        public SchoolContext() { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StuCrsRes> StuCrsRes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SchoolManagementDb2;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تغيير كل الـ Cascade إلى Restrict
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // تغيير إلى Restrict

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // تغيير إلى Restrict

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); // تغيير إلى Restrict

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(scr => scr.Student)
                .WithMany(s => s.StuCrsRes)
                .HasForeignKey(scr => scr.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StuCrsRes>()
                .HasOne(scr => scr.Course)
                .WithMany(c => c.StuCrsRes)
                .HasForeignKey(scr => scr.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StuCrsRes>()
                .HasKey(scr => new { scr.StudentId, scr.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}