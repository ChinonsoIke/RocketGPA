using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPA.Models
{
    public class Student
    {
        public List<Course> Courses { get; set; } = new();
        public int TotalCourseUnits { get; set; } = 0;
        public int TotalCourseUnitsPassed { get; set; } = 0;
        public int TotalWeightPoints { get; set; } = 0;
    }
}
