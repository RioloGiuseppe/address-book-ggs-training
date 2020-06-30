using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_sample.Models
{
    public class AddStudentToGradeModel
    {
        public Student Student { get; set; }
        public int GradeId { get; set; }
    }
}
