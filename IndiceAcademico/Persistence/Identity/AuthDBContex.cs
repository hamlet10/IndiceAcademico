using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndiceAcademico.Persistence.Identity
{
    public class AuthDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<ApplicationRole> applicationRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(a =>
            {
                a.HasKey(u => u.Id);
                a.HasIndex(u => u.NormalizedEmail).IsUnique();
            });
        }

    }

}
