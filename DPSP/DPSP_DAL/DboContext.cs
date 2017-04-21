﻿using System.Data.Entity;

namespace DPSP_DAL
{
    public class DboContext : DbContext
    {
        public DboContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
        {

        }


        public DbSet<User> Users { get; set; }

        //public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        //public DbSet<UserToRole> UserToRoles { get; set; }

        public DbSet<Project> Projects { get; set; }

        //public DbSet<UserToProject> UserToProjects { get; set; }

        //public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<User>()
            //            .HasMany<Project>(s => s.Projects)
            //            .WithMany(c => c.Users)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("UserRefId");
            //                cs.MapRightKey("ProjectRefId");
            //                cs.ToTable("UserProject");
            //            });

        }
    }
}