namespace Simplex.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Simplex.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Simplex.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Simplex.Models.ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager= new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@simplexB.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@simplexB.com",
                    Email = "admin@simplexB.com"
                };
                userManager.Create(user,"p@ssw0rD");

                var adminCustomer = new Customer { Name = "Admin", Id = Convert.ToInt32(user.Id) };

                context.Roles.AddOrUpdate(r=>r.Name, new IdentityRole {Name="CanManageCustomers"});

                context.SaveChanges();

                userManager.AddToRole(user.Id, "CanManageCustomers");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
