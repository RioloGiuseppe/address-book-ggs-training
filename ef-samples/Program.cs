using ef_samples.ManyToMany;
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
            
            /// Creo istanza contesto
            var ctx1 = new M2MContext();

            /// Creo dati per tabelle
            Student s1 = new Student() { StudentName = "Giovanni" };
            Student s2 = new Student() { StudentName = "Alberto" };
            Student s3 = new Student() { StudentName = "Francesca" };

            Course c1 = new Course() { CourseName = "Informatica" };
            Course c2 = new Course() { CourseName = "Lettere" };
            Course c3 = new Course() { CourseName = "Matematica" };

            /// Definisco le relazioni
            s1.Courses.Add(c1);
            s1.Courses.Add(c2);

            s2.Courses.Add(c2);
            s2.Courses.Add(c3);

            s3.Courses.Add(c3);
            s3.Courses.Add(c1);

            /// Aggiungo studenti 
            ctx1.Students.Add(s1);
            ctx1.Students.Add(s2);
            ctx1.Students.Add(s3);

            /// Salvo modifiche
            ctx1.SaveChanges();
        }
    }
}
