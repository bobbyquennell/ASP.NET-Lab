using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GPASystem.Web.Models.Lesson
{
    public class LessonEditViewModel
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string TeacherName { get; set; }
    }
}