using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspNetWebApiWithKnockoutJs.Models
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext() : base("KnockoutJsApp")
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}