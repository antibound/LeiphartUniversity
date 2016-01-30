using LeiphartUniversity.Controllers;
using LeiphartUniversity.DAL;
using LeiphartUniversity.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LeiphartUniversity.Tests.Controllers
{
    class StudentControllerTests
    {
        public Mock<IStudentRepository> studentsMock;
        Mock<DbSet<Student>> mockSet;

        [OneTimeSetUp]
        public void SetupData()
        {
            studentsMock = new Mock<IStudentRepository>();
            var students = new Student[]{
            new Student() { ID = 1930586204, FirstName = "Kenneth", LastName = "Leiphart" },
            new Student() { ID = 2052873025, FirstName = "Diana", LastName = "Leiphart" },
            new Student() { ID = 3621126689, FirstName = "Eric", LastName = "Lakatosh" },
            new Student() { ID = 1115790449, FirstName = "Joseph", LastName = "Smith" }
            }.AsQueryable();

            mockSet = new Mock<DbSet<Student>>();
            mockSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(students.Provider);
            mockSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(students.Expression);
            mockSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(students.ElementType);
            mockSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(students.GetEnumerator());

            studentsMock.Setup(m => m.Students).Returns(mockSet.Object);
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

            var students = controller.FirstNameSearch("eth");

            Assert.AreEqual(1, students.Count);
        }

        [TestCase]
        public void Student_First_Name_Search_Capitalization_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = controller.FirstNameSearch("ken");

            Assert.AreEqual(1, students.Count);
        }

        [TestCase]
        public void Student_Last_Name_WildCard_In_Front_Search_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = controller.LastNameSearch("art");

            Assert.AreEqual(2, students.Count);
        }

        [TestCase]
        public void Student_Last_Name_Search_Capitalization_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = controller.LastNameSearch("lei");

            Assert.AreEqual(2, students.Count);
        }

        [TestCase]
        public void Student_ID_Wildcard_In_Front_Search_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = controller.IdSearch("6204");

            Assert.AreEqual(1, students.Count);
        }

        [TestCase]
        public void Is_Student_Currently_Enrolled_In_School_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = controller.IsEnrolled("1930586204");
        }

        [TestCase]
        public void Create_Student_Successfully_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);
            Student student = new Student();

            student.FirstName = "Dave";
            student.LastName = "Winner";

            controller.Create(student);

            mockSet.Verify(s => s.Add(It.IsAny<Student>()), Times.Once());
        }

        public void Create_Student_Failed_No_First_Name_Test()
        {
            StudentController controller = new StudentController(studentsMock.Object);
            Student student = new Student();

            student.FirstName = "Dave";
            student.LastName = "Winner";

            ViewResult view = controller.Create(student);

            mockSet.Verify(s => s.Add(It.IsAny<Student>()), Times.Once());
            Assert.Equals("First name is required.", )
        }
        //Create_Student_Failed_No_Last_Name_Test
        //Create_Student_Failed_ID_Already_Exists_Test (Pobably should just retry the id creation instead of a failure)
        //Student_Enroll_In_Class_Successfully_Test
        //Student_Enroll_In_Class_Failed_Not_Current_Student_Test
        //Student_Enroll_In_Class_Failed_Class_Overlaps_Other_Class_Test
        //Student_Enroll_In_Class_Failed_Unmet_Requirements_Test
    }
}
