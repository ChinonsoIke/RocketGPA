using RocketGPA.Helpers;
using RocketGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPA.Core
{
    public class GradingService
    {
        /// <summary>
        /// Calculate student GPA
        /// </summary>
        /// <param name="student">Instance of student class</param>
        public static void Calculate(Student student)
        {
            double gpa = (double)student.TotalWeightPoints / student.TotalCourseUnits;

            PrintTable.Print(student, gpa);
        }
    }
}
