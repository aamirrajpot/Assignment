using DataLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IStudentRepository
    {
        Task<int> Add(StudentDto student);
        Task<int> Delete(int Id);
        Task<Student> GetById(int Id);
        Task<List<Student>> GetStudents();
        Task Update(Student student);
    }
}