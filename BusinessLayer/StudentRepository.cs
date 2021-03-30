using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IStudentCourseRepository studentCourseRepository;

        public StudentRepository(ApplicationDbContext context,IStudentCourseRepository studentCourseRepository)
        {
            this.context = context;
            this.studentCourseRepository = studentCourseRepository;
        }
        public async Task<List<Student>> GetStudents()
        {
            if (context != null)
            {
                //var dta = await context.Students.FromSqlRaw("SELECT Students.* FROM Courses INNER JOIN StudentCourses ON Courses.Id = StudentCourses.AddressId INNER JOIN Students ON StudentCourses.UserId = Students.Id WHERE (Courses.Id = 1)").ToListAsync();
                var data = await context.Students.ToListAsync();
                return data;
            }
            return null;
        }



        public async Task<Student> GetById(int Id)
        {
            if (context != null)
            {
                return await context.Students.FirstOrDefaultAsync(s => s.Id == Id);
            }

            return null;
        }

        public async Task<int> Add(StudentDto student)
        {
            try
            {
                if (context != null)
                {
                    Student st = new Student
                    {
                        Name = student.Name,
                        RollNo = student.RollNo,
                        Phone = student.Phone,
                        Email = student.Email,
                        Address = student.Address
                    };
                    if (student.courseIds.Any())
                    {
                        List<StudentCourse> studentCoursesList = new List<StudentCourse>();
                        foreach (var item in student.courseIds)
                        {
                            StudentCourse sc = new StudentCourse();
                            sc.Student = st;
                            sc.Course = context.Courses.FirstOrDefault(x => x.Id == item);
                            studentCoursesList.Add(sc);
                        }
                        st.StudentCourses = studentCoursesList;
                    }
                    await context.Students.AddAsync(st);
                    await context.SaveChangesAsync();
                    return st.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Server error !");
            }
        }

        public async Task<int> Delete(int Id)
        {
            int result = 0;

            if (context != null)
            {
                //Find for specific student id
                var student = await context.Students.FirstOrDefaultAsync(s => s.Id == Id);

                if (student != null)
                {
                    //Delete 
                    context.Students.Remove(student);

                    //Commit the transaction
                    result = await context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task Update(Student student)
        {
            if (context != null)
            {
                context.Students.Update(student);
                await context.SaveChangesAsync();
            }
        }
    }
}
