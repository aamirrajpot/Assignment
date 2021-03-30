using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int[] courseIds { get; set; }
    }
}
