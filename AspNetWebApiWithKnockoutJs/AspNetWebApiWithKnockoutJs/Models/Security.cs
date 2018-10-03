using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWebApiWithKnockoutJs.Models
{
    public class Security : IdentityDbContext<AppUser>
    {
        public Security() : base("KnockoutJsIdentity")
        {

        }
    }

    public class AppUser : IdentityUser
    {

    }
}