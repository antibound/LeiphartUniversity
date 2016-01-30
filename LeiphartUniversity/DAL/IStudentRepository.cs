using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeiphartUniversity.Models;
using System.Data.Entity;

namespace LeiphartUniversity.DAL
{
    public interface IStudentRepository
    {
        DbSet<Student> Students { get; }
    }
}