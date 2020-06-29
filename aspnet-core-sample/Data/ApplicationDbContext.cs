using System;
using System.Collections.Generic;
using System.Text;
using aspnet_core_sample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_sample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>()
                .HasOne<Grade>(s => s.CurrentGrade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);
        }
    }
}
