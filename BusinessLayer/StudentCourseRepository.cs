using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ApplicationDbContext context;

        public StudentCourseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Course>> GetStudentCourses(int Id)
        {
            if (context != null)
            {
                var courses= await context.Courses.FromSqlRaw("select Courses.* from Courses left join StudentCourses on Courses.Id = StudentCourses.CourseId where StudentCourses.StudentId =" + Id +"").ToListAsync();
                return courses; 
            }

            return null;
        }
        public async Task<List<Student>> GetCourseStudents(int Id)
        {
            if (context != null)
            {
                var students = await context.Students.FromSqlRaw("  select Students.* from Students join StudentCourses on Students.Id = StudentCourses.StudentId where StudentCourses.CourseId =" + Id + "").ToListAsync();
                return students;
            }

            return null;
        }
    }
}
