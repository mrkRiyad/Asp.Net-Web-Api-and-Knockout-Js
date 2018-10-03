namespace AspNetWebApiWithKnockoutJs.Migrations
{
    using AspNetWebApiWithKnockoutJs.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetWebApiWithKnockoutJs.Models.Security>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspNetWebApiWithKnockoutJs.Models.Security context)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new Security()));
            var user = new AppUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };

            userManager.Create(user, "Test@123");

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rolemanager.Create(new IdentityRole("Admin"));

            userManager.AddToRole(user.Id, "Admin");
        }
    }
}
