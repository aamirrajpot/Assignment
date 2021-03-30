using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepositoy;

        public StudentsController(IStudentRepository studentRepositoy)
        {
            this.studentRepositoy = studentRepositoy;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Student>> GetAll()
        {
                return await studentRepositoy.GetStudents();
        }
        public async Task<Student> GetById(int Id)
        {
                return await studentRepositoy.GetById(Id);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<int> Add(StudentDto student)
        {
            return await studentRepositoy.Add(student);
        }
        [Route("Delete")]
        public async Task<int> Delete(int Id)
        {
            return await studentRepositoy.Delete(Id);
        }

        [Route("Update")]
        public async Task Update(Student student)
        {
            
            await studentRepositoy.Update(student);
        }
    }
}
