﻿using Microsoft.AspNet.Identity.EntityFramework;
using ST.Core;
using ST.Core.Models;
using ST.DAL.EntityConfigs;
using System.Data.Entity;

namespace ST.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("SkillTrackerDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SkillConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
            modelBuilder.Configurations.Add(new ApplicationUserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}