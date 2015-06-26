using System;
using Moq;
using NUnit.Framework;
using GPASystem.Web.Models.Lesson;
using GPA.Domain.Repositories;
using GPA.Domain.Entities;
using GPASystem.Web.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;

namespace GPASystem.Web.Tests.Controllers
{
    [TestFixture]
    public class LessonControllerTest
    {
        [Test]
        public void Create_Should_Add_A_New_Lesson()
        {
            //arrange
            IList<Course> Lessons = new List<Course>{
                new Course
                {
                    Name = "Biology",
                    Location = "Building 5 Room 201",
                    TeacherName = "Mr Robertson",
                    Students = new List<Student>() { 
                         new Student(){ Name = "David Jackson", Age=19, Gpa= 3.4},
                         new Student(){ Name = "Peter Parker", Age= 19, Gpa = 2.9},
                         new Student(){Name="Robert Smith", Age=18, Gpa =3.1},
                         new Student(){Name="Rebecca Black", Age =19, Gpa=2.1}
                    }
                },
                new Course
                {
                    Name = "English",
                    Location = "Building 3 Room 134",
                    TeacherName = "Miss Sanderson",
                    Students = new List<Student>() { 
                        new Student(){ Name = "David Beckham", Age=19, Gpa= 3.4},
                        new Student(){ Name = "Peter Obama", Age= 19, Gpa = 2.9},
                        new Student(){Name="Robert Merkel", Age=18, Gpa =3.1},
                        new Student(){Name="Rebecca Albert", Age =19, Gpa=2.1}
                    }
                }
            };
            
            Mock<IRepository> GpaRepoMock = new Mock<IRepository>();
            GpaRepoMock.Setup(r => r.Add<Course>(It.IsAny<Course>())).Callback<Course>(new Action<Course>(
                    r => {
                    Lessons.Add(r);
                }
                ));
            LessonController sut = new LessonController(GpaRepoMock.Object);

            LessonEditViewModel model = new LessonEditViewModel();
            //act
            ActionResult result = sut.Create(model);

            //assert
            Assert.That(Lessons.Count, Is.EqualTo(3));

        }
    }
}
