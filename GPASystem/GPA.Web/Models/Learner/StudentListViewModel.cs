using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPA.Web.Models.Learner
{
    public class StudentListViewModel
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
        public double Gpa { get; set; }
        public int Id { get; set; }
    }
    public class StudentIndexViewModel
    {
        public int CourseId { get; set; }
        public IEnumerable<StudentListViewModel> Students { get; set; }
    }
}
