using System.Linq;
using IndiceAcademico.Models;
using IndiceAcademico.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IndiceAcademico.Persistence
{
    public static class AuthInitializer
    {

        public static void Initialize(AuthDBContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var users = new ApplicationUser[]
            {

                    new ApplicationUser {
                        Email = "francia.mejia@intec.edu.do",
                        NormalizedEmail = "francia.mejia@intec.edu.do",
                        LockoutEnabled = false,
                        AccessFailedCount =0
                    },
                     new ApplicationUser {
                        Email = "1059560@intec.edu.do",
                        NormalizedEmail = "1059560@intec.edu.do",
                        LockoutEnabled = false,
                        AccessFailedCount =0
                    },
                     new ApplicationUser {
                        Email = "1096394@intec.edu.do",
                        NormalizedEmail = "1096394@intec.edu.do",
                        LockoutEnabled = false,
                        AccessFailedCount =0
                    },
                    new ApplicationUser {
                        Email = "1095352@intec.edu.do",
                        NormalizedEmail = "1095352@intec.edu.do",
                        LockoutEnabled = false,
                        AccessFailedCount =0
                    }
            };
            var password = new PasswordHasher<ApplicationUser>();
            foreach (var user in users)
            {
               
                user.PasswordHash = password.HashPassword(user, "Intec123!");
                context.applicationUsers.Add(user);
            }

            context.SaveChanges();

            var roles = new ApplicationRole[]
            {
                new ApplicationRole() { Name = "Admin", NormalizedName = "ADMIN"},
                new ApplicationRole() { Name = "Professor", NormalizedName = "PROFESSOR"},
                new ApplicationRole() { Name = "Student", NormalizedName = "STUDENT"},
            };

            foreach (var role in roles)
            {
               
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var userRoles = new ApplicationUserRole[]
            {
                new ApplicationUserRole(){ UserId = 1, RoleId = 3},
                new ApplicationUserRole(){ UserId = 1, RoleId = 2},
                new ApplicationUserRole(){ UserId = 2, RoleId = 1},
                new ApplicationUserRole(){ UserId = 3, RoleId = 1},
                new ApplicationUserRole(){ UserId = 4, RoleId = 1},
            };
            foreach (var userRole in userRoles)
            {
               
                context.UserRoles.Add(userRole);
            }
            context.SaveChanges();
        }
    }
}