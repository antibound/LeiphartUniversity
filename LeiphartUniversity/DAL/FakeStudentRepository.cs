using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LeiphartUniversity.Models;

namespace LeiphartUniversity.DAL
{
    public class FakeStudentRepository : IStudentRepository
    {
        public FakeStudentRepository()
        {
        }

        public virtual DbSet<Student> Students
        {
            get
            {
                return null;
            }
        }
    }
}