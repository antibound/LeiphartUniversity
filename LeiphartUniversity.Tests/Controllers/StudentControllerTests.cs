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
            new Student() { ID = 1, FirstMidName = "Kenneth", LastName = "Leiphart",EnrollmentDate=DateTime.Parse("2005-09-01") },
            new Student() { ID = 2, FirstMidName = "Diana", LastName = "Leiphart",EnrollmentDate=DateTime.Parse("2005-09-01") },
            new Student() { ID = 3, FirstMidName = "Eric", LastName = "Lakatosh",EnrollmentDate=DateTime.Parse("2005-09-01") },
            new Student() { ID = 4, FirstMidName = "Joseph", LastName = "Smith",EnrollmentDate=DateTime.Parse("2005-09-01") }
            }.AsQueryable());
        }

        [TestCase]
        public void StudentIndexReturnsAll()
        {
            StudentController controller = new StudentController(studentsMock.Object);

            var students = (List<Student>)controller.Index().Model;

            Assert.AreEqual(4, students.Count);
        }
    }
}
