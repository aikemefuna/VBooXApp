using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using VBooX.Application.Enums;
using VBooX.Infrastructure.Identity.Models;

namespace VBooX.Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@vboox.com.ng",
                Email = "admin@vboox.com.ng",
                FirstName = "Admin",
                LastName = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "@Reetah39");
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }

            }
        }
    }
}
