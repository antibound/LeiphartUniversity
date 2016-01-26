using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeiphartUniversity.Models;

namespace LeiphartUniversity.DAL
{
    public interface IStudentRepository
    {
        IQueryable<Student> Students { get; }
    }
}