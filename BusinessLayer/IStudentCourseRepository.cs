using DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IStudentCourseRepository
    {
        Task<List<Student>> GetCourseStudents(int Id);
        Task<List<Course>> GetStudentCourses(int Id);

    }
}