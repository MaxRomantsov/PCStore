﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PCStore.Core.Entities.User;
using PCStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Infrastructure.Initializers
{
    public static class UsersAndRolesInitializer
    {
        public static async Task SeedUsersAndRoles(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateAsyncScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                UserManager<AppUser> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                if (userManager.FindByEmailAsync("admin@email.com").Result == null)
                {
                    AppUser admin = new AppUser()
                    {
                        UserName = "admin",
                        FirstName = "John",
                        LastName = "Snow",
                        Email = "admin@email.com",
                        EmailConfirmed = true,
                        PhoneNumber = "+xx(xxx)xxx-xx-xx",
                        PhoneNumberConfirmed = true,
                    };
                    context.Roles.AddRange(
                        new IdentityRole()
                        {
                            Name = "administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new IdentityRole()
                        {
                            Name = "user",
                            NormalizedName = "USER"
                        },
                        new IdentityRole()
                        {
                            Name = "owner",
                            NormalizedName = "OWNER"
                        },
                        new IdentityRole()
                        {
                            Name = "moderator",
                            NormalizedName = "MODERATOR"
                        });
                    await context.SaveChangesAsync();
                    IdentityResult adminResult = userManager.CreateAsync(admin, "Qwerty-1").Result;
                    if (adminResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(admin, "Administrator").Wait();
                    }
                }
            }
        }
    }
}
