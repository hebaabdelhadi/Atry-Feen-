using AH.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AH.Startup))]
namespace AH
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRoles();
            Createuser();

        }





        public void Createuser()
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "esraa.13sa2a@gmail.com";
            user.UserName = "sa2a";
            user.PhoneNumber = "01119948171";
            user.Name = "Esraa Gaber";
            var check = userManager.Create(user, "0105800137Ee@");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }


        }


        public void CreateRoles()
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role;
            if (!roleManager.RoleExists("Admins"))
            {
                role = new IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);
            }

        }












    }
}
