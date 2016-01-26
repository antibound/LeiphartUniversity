using LeiphartUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var students = from s in db.Students
                           select s;

            return View(db.Students.ToList());
        }
    }
}