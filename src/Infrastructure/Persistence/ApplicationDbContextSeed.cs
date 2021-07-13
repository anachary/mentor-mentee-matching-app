﻿using MentorMenteeApp.Domain.Entities;
using MentorMenteeApp.Domain.ValueObjects;
using MentorMenteeApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace MentorMenteeApp.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
            }

            var administrator = new User { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new [] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            //// Seed, if necessary
            //if (!context.Skills.Any())
            //{
            //    context.Skills.Add(new Skill
            //    {
            //        Name = "Shopping",
            //        Id = 1
            //     });

            //    await context.SaveChangesAsync();
            //}
        }
    }
}
