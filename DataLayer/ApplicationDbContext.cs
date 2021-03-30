using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse>  StudentCourses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
            .HasKey(t => new { t.StudentId, t.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Student)
                .WithMany(p => p.StudentCourses)
                .HasForeignKey(pt => pt.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(pt => pt.Course)
                .WithMany(t => t.StudentCourses)
                .HasForeignKey(pt => pt.CourseId);

        }
    }
}
