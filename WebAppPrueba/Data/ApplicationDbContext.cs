using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppPrueba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "admin", NormalizedName = "ADMIN".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "8c6e173g-6b0s-126f-86af-483d56fd7210", Name = "client", NormalizedName = "CLIENT".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "client")
                },
                new ApplicationUser
                {
                    Id = "9a445865-a24d-4543-a6c6-6443d048cdv1", // primary key
                    UserName = "client",
                    NormalizedUserName = "client",
                    PasswordHash = hasher.HashPassword(null, "client")
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                //admin
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },

                //client
                new IdentityUserRole<string>
                {
                    RoleId = "8c6e173g-6b0s-126f-86af-483d56fd7210",
                    UserId = "9a445865-a24d-4543-a6c6-6443d048cdv1"
                }


            );


        }


    }
}
