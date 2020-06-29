using ef_samples.ManyToMany;
using ef_samples.OneToMany;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_samples
{
    class Program
    {
        static void Main(string[] args)
        {

            ///// Creo istanza contesto
            //var ctx1 = new M2MContext();

            ///// Creo dati per tabelle
            //Student s1 = new Student() { StudentName = "Giovanni" };
            //Student s2 = new Student() { StudentName = "Alberto" };
            //Student s3 = new Student() { StudentName = "Francesca" };

            //Course c1 = new Course() { CourseName = "Informatica" };
            //Course c2 = new Course() { CourseName = "Lettere" };
            //Course c3 = new Course() { CourseName = "Matematica" };

            ///// Definisco le relazioni
            //s1.Courses.Add(c1);
            //s1.Courses.Add(c2);

            //s2.Courses.Add(c2);
            //s2.Courses.Add(c3);

            //s3.Courses.Add(c3);
            //s3.Courses.Add(c1);

            ///// Aggiungo studenti 
            //ctx1.Students.Add(s1);
            //ctx1.Students.Add(s2);
            //ctx1.Students.Add(s3);

            ///// Salvo modifiche
            //ctx1.SaveChanges();

            /// Creo istanza contesto
            var ctx1 = new O2MContext();

            /// Creo dati per tabelle
            OneToMany.Student s1 = new OneToMany.Student() { Name = "Giovanni" };
            OneToMany.Student s2 = new OneToMany.Student() { Name = "Alberto" };
            OneToMany.Student s3 = new OneToMany.Student() { Name = "Francesca" };

            Grade g1 = new Grade() { GradeName = "Grade1" };
            Grade g2 = new Grade() { GradeName = "Grade2" };
            Grade g3 = new Grade() { GradeName = "Grade3" };

            /// Definisco le relazioni
            g1.Students.Add(s1);
            g1.Students.Add(s2);

            g2.Students.Add(s2);
            g2.Students.Add(s3);

            g3.Students.Add(s3);
            g3.Students.Add(s1);

            ///// Aggiungo studenti 
            ctx1.Grades.Add(g1);
            ctx1.Grades.Add(g2);
            ctx1.Grades.Add(g3);

            /// Salvo modifiche
            ctx1.SaveChanges();
        }
    }
}
