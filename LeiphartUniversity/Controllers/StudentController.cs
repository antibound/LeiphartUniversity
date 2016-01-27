﻿using LeiphartUniversity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeiphartUniversity.Models;

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
    }
}