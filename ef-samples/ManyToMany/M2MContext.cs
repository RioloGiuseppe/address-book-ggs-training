using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_samples.ManyToMany
{
    public class M2MContext : DbContext
    {
        public M2MContext() : base("SQLServer1")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany<Course>(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(cs =>
                {
                    cs.MapLeftKey("StudentRefId");
                    cs.MapRightKey("CourseRefId");
                    cs.ToTable("StudentCourse");
                });
        }
    }
}