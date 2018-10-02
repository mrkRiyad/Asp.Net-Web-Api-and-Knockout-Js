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
    // api/course
    public class CourseController : ApiController
    {
        StudentDbContext db = new StudentDbContext();


        public IEnumerable<CourseViewModel> Get()
        {
            var model = db.Courses.Select(c => new CourseViewModel
            {
                CourseID = c.CourseID,
                CourseName = c.CourseName
            });
            return model;
        }


        public CourseViewModel Get(int id)
        {
            var c = db.Courses.Find(id);
            var model = new CourseViewModel
            {
                CourseID = c.CourseID,
                CourseName = c.CourseName
            };
            return model;
        }
    }
}
