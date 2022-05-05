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
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "8c6e173g-6b0s-123f-86af-483d46fd7211", Name = "client", NormalizedName = "CLIENT".ToUpper(), });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "6c6e173u-5b0s-026f-86af-583d56fd7211", Name = "user", NormalizedName = "USER".ToUpper(), });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<ApplicationUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "admin"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "9a445865-a24d-4543-a6c6-6443d048cdv1", // primary key
                    UserName = "client",
                    NormalizedUserName = "client",
                    PasswordHash = hasher.HashPassword(null, "client"),
                    EmailConfirmed  = true
                },
                new ApplicationUser
                {
                    Id = "6a445865-a24d-4123-a6c3-8043d048cdv1", // primary key
                    UserName = "user",
                    NormalizedUserName = "user",
                    PasswordHash = hasher.HashPassword(null, "user"),
                    EmailConfirmed = true
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
                    RoleId = "8c6e173g-6b0s-123f-86af-483d46fd7211",
                    UserId = "9a445865-a24d-4543-a6c6-6443d048cdv1"
                },

                new IdentityUserRole<string>
                {
                    RoleId = "6c6e173u-5b0s-026f-86af-583d56fd7211",
                    UserId = "6a445865-a24d-4123-a6c3-8043d048cdv1"
                }


            );


        }


    }
}
