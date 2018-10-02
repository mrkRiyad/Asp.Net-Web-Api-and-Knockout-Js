using AspNetWebApiWithKnockoutJs.Models;
using AspNetWebApiWithKnockoutJs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetWebApiWithKnockoutJs.Controllers
{
    // api/student
    public class StudentController : ApiController
    {
        StudentDbContext db = new StudentDbContext();

        
        public IEnumerable<StudentViewModel> Get()
        {
            var model = db.Students.Select(s => new StudentViewModel
            {
                StudentID = s.StudentID,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email,
                ProfileImageUrl = s.ProfileImageUrl,
                CourseID = s.fkCourseID
            });
            return model;
        }

        
        public StudentViewModel Get(int id)
        {
            var s = db.Students.Find(id);
            var model = new StudentViewModel
            {
                StudentID = s.StudentID,
                Name = s.Name,
                Age = s.Age,
                Email = s.Email,
                ProfileImageUrl = s.ProfileImageUrl,
                CourseID = s.fkCourseID
            };
            return model;
        }

        
        public void Post(StudentViewModel std)
        {
            if (std.StudentID == 0) 
            {
                Student student = new Student();    
                student.Name = std.Name;
                student.Age = std.Age;
                student.Email = std.Email;
                student.ProfileImageUrl = std.ProfileImageUrl;
                student.fkCourseID = std.CourseID;
                if (ModelState.IsValid) 
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
            }
            else
            {
                Student student = db.Students.Find(std.StudentID);
                if (student != null)
                {
                    student.Name = std.Name;
                    student.Age = std.Age;
                    student.Email = std.Email;
                    student.ProfileImageUrl = std.ProfileImageUrl;
                    student.fkCourseID = std.CourseID;
                }
                db.SaveChanges();
            }
        }

        
        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}
