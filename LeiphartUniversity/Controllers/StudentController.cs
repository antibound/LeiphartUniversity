using LeiphartUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeiphartUniversity.Models;
using LeiphartUniversity.Helpers;

namespace LeiphartUniversity.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository db;

        public StudentController(IStudentRepository studentRepo)
        {
            db = studentRepo;
        }
        // GET: Student
        public ViewResult Index()
        { 
            return View(db.Students.ToList());
        }

        public List<Student> FirstNameSearch(string v)
        {
            var students = from s in db.Students
                           where s.FirstName.ToLower().Contains(v)
                           select s;

            return students.ToList();
        }

        public List<Student> LastNameSearch(string name)
        {
            var students = from s in db.Students
                           where s.LastName.ToLower().Contains(name)
                           select s;

            return students.ToList();
        }

        public List<Student> IdSearch(string id)
        {
            var students = from s in db.Students
                           where s.ID.ToString().Contains(id)
                           select s;

            return students.ToList();
        }

        public bool IsEnrolled(string id)
        {
            var students = from s in db.Students
                           where s.ID.ToString().Equals(id)
                           select s;

            return students.Count() == 0 ? true : false;
        }

        public void Create(Student student)
        {
            Utilities utility = new Utilities();
            Random random = new Random();

            student.ID = utility.GenerateUniversityId(random);
            db.Students.Add(student);            
        }
    }
}