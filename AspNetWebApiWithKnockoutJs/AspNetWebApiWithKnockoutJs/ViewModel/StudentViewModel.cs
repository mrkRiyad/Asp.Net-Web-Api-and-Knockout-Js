using AspNetWebApiWithKnockoutJs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetWebApiWithKnockoutJs.ViewModel
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [Range(24, 32)]
        public int Age { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public int CourseID { get; set; }
    }
}