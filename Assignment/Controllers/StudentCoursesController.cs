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
    [Route("api/StudentCourses")]
    [ApiController]
    public class StudentCoursesController : ControllerBase
    {
        private readonly IStudentCourseRepository studentCourseRepository;

        public StudentCoursesController(IStudentCourseRepository studentCourseRepository)
        {
            this.studentCourseRepository = studentCourseRepository;
        }
        [HttpGet]
        [Route("GetCourseStudents")]
        public async Task<List<Student>> GetCourseStudents(int Id=1)
        {
            var data = await studentCourseRepository.GetCourseStudents(Id);
            return data;
        }
        [HttpGet]
        [Route("GetStudentCourses")]
        public async Task<List<Course>> GetStudentCourses(int Id = 1)
        {
            var data = await studentCourseRepository.GetStudentCourses(Id);
            return data;
        }
    }
}
