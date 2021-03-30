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
    [Route("api/Courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepositoy;

        public CoursesController(ICourseRepository courseRepositoy)
        {
            this.courseRepositoy = courseRepositoy;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Course>> GetAll()
        {
            return await courseRepositoy.GetCourses();
        }
        public async Task<Course> GetById(int Id)
        {
            return await courseRepositoy.GetById(Id);
        }

        public async Task<int> Add(Course Course)
        {
            return await courseRepositoy.Add(Course);
        }

        public async Task<int> Delete(int Id)
        {
            return await courseRepositoy.Delete(Id);
        }


        public async Task Update(Course Course)
        {
            await courseRepositoy.Update(Course);
        }
    }
}
