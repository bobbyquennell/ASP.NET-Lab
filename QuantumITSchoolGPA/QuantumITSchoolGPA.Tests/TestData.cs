using QuantumITSchoolGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumITSchoolGPA.Tests
{
    class TestData
    {
        public static IQueryable<Class> Classes
        {
            get
            {
                var Classes = new List<Class>();
                for (int i = 0; i < 4; i++)
                {
                    string index = i.ToString();
                    Random random = new Random();
                    float FakeGpa = (float)(random.Next(5)+ random.NextDouble());
                   
                    var course = new Class();
                    course.Location = "fake location " + index;
                    course.Name = "fake CourseName" + index;
                    course.TeacherName = "fake TeacherName " + index;
                    course.Students = new List<Student>(){
                        new Student{ Age = 18,
                         Name ="FakeStuFName"+index + " " + "FakeStuLName"+index,
                         GPA = FakeGpa,
                          ClassId = i,
                         Id= i }};
                    Classes.Add(course);
                }
                return Classes.AsQueryable();
            }
        }
    }
}
