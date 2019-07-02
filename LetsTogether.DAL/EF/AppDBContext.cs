using LetsTogether.DAL.Entities;     
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.EF
{
 public class AppDBContext : IdentityDbContext<User> 
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventPhoto> EventPhotos { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<EventVisitors> EventVisitors { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.Migrate();
        }
                          
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            );

            builder.Entity<IdentityUser>().ToTable("IdentityUser");
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        }
    }
}
