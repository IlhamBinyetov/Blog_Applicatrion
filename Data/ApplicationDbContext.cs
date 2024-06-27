using Blog_Applicatrion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Applicatrion.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogApplication.db");
            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
             .HasMany(b => b.Tags)
             .WithOne(t => t.Blog)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Blog)
                .WithMany(b => b.Tags)
                .HasForeignKey(t => t.BlogId);
        }
    }


    
}
