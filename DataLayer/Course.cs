using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseNo { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
