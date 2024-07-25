using Microsoft.AspNetCore.Identity;
using Core.Entities.Identity;


namespace Infrastructure.Identity
{
    public  class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Gaga",
                    Email = "gaga@test.com",
                    UserName = "gaga93",
                    Address = new Address
                    {
                        FirstName = "Dragana",
                        LastName = "Savanovic",
                        City = "Banja Luka",
                        Street = "MG23",
                        State = "RS",
                        ZipCode = "78000"
                    }
                };

                await userManager.CreateAsync(user, "g@G@123");
            }
        }
    }
}
