using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
