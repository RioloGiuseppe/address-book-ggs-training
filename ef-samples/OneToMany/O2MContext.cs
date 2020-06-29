using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_samples.OneToMany
{
    class O2MContext : DbContext
    {
        public O2MContext() : base("SQLServer1")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Student>()
                .HasRequired<Grade>(s => s.CurrentGrade)
                .WithMany(g => g.Students)
                .HasForeignKey<int>(s => s.CurrentGradeId);
        }
    }
}

