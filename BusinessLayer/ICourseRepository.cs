using DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICourseRepository
    {
        Task<int> Add(Course Course);
        Task<int> Delete(int Id);
        Task<Course> GetById(int Id);
        Task<List<Course>> GetCourses();
        Task Update(Course Course);
    }
}