using IdentityFramWork.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityFramwork.Controllers.Utilities
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
           RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            await SeedRoles(roleManager);
            await SeedAdminUser(userManager);
           


        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new[] { "Admin" };
            foreach(string role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager) 
        {
            ApplicationUser? AdminUser = await userManager.FindByNameAsync("Admin");
            if(AdminUser == null)
            {
                ApplicationUser Admin = new()
                {
                    UserName = "Admin",
                    Email = "Admin@gmail.com",
                    FirstName = "",
                    LastName = "",
                    TRN = ""
                };

                IdentityResult createAdmin = await userManager.CreateAsync(Admin, "Admin527$");
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(Admin);
                await userManager.ConfirmEmailAsync(Admin, confirmationToken);
                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(Admin, "Admin");
                }
                
            }
        }
            

    }
}
