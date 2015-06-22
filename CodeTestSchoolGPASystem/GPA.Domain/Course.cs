using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPA.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public string TeacherName { get; set; }
        public List<Student> Students { get; set; }
    }
}
