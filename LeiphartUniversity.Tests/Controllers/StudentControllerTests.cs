using LeiphartUniversity.Controllers;
using LeiphartUniversity.DAL;
using LeiphartUniversity.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeiphartUniversity.Tests.Controllers
{
    class StudentControllerTests
    {
        public Mock<IStudentRepository> studentsMock;

        [OneTimeSetUp]
        public void SetupData()
        {
            studentsMock = new Mock<IStudentRepository>();

            studentsMock.Setup(m => m.Students).Returns(new Student[]{
            new Student() { ID = 1930586204, FirstName = "Kenneth", LastName = "Leiphart" },
            new Student() { ID = 2052873025, FirstName = "Diana", LastName = "Leiphart" },
            new Student() { ID = 3621126689, FirstName = "Eric", LastName = "Lakatosh" },
            new Student() { ID = 1115790449, FirstName = "Joseph", LastName = "Smith" }
            }.AsQueryable());
        }

        [TestCase]
        public void Student_Index_Returns_All_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.Index().Model;

            Assert.AreEqual(4, students.Count);
        }

        [TestCase]
        public void Student_First_Name_WildCard_In_Front_Search_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.FirstNameSearch("eth");

            Assert.AreEqual(1, students.Count);
        }

        [TestCase]
        public void Student_First_Name_Search_Capitalization_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.FirstNameSearch("ken");

            Assert.AreEqual(1, students.Count);
        }

        [TestCase]
        public void Student_Last_Name_WildCard_In_Front_Search_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.LastNameSearch("art");

            Assert.AreEqual(2, students.Count);
        }

        [TestCase]
        public void Student_Last_Name_Search_Capitalization_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.LastNameSearch("lei");

            Assert.AreEqual(2, students.Count);
        }

        [TestCase]
        public void Student_ID_Wildcard_In_Front_Search_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.IdSearch("6204");

            Assert.AreEqual(1, students.Count);
        }
    }
}
