using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class Student : Person
    {
        public string Major { get; set; }

        public double GPA { get; set; }
    }
}
