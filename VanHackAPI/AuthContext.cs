using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VanHackAPI.Models;

namespace VanHackAPI
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categorys { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topic>().ToTable("Topics");
            modelBuilder.Entity<Topic>().HasKey(x => x.Id);
            modelBuilder.Entity<Topic>().Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<ApplicationUser>().HasMany(x => x.Topics).WithMany().Map(x =>
            {
                x.ToTable("UserTopics");
                x.MapLeftKey("UserId");
                x.MapRightKey("TopicId");
            });
        }
    }
}