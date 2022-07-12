using RocketGPA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RocketGPA.Helpers
{
    public class PrintTable
    {
        /// <summary>
        /// Print table containing information about student's courses and grades, and 
        /// additional lines containing calculated totals
        /// </summary>
        /// <param name="student">Instance of student class</param>
        /// <param name="gpa">Calculated GPA</param>
        public static void Print(Student student, double gpa)
        {
            Console.WriteLine($"| {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");
            Console.WriteLine($"| {"COURSE CODE",-15} | {"COURSE UNIT",-15} | {"GRADE",-15} | {"GRADE UNIT",-15} | {"WEIGHT PT.",-15} | {"REMARK",-15} |");
            Console.WriteLine($"| {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");
            foreach (Course course in student.Courses)
            {
                Thread.Sleep(300);
                Console.WriteLine($"| {course.CourseCode,-15} | {course.CourseUnits,-15} | {course.StudentGrade,-15} | {(int)course.StudentGrade,-15} | {course.WeightPoint,-15} | {course.StudentGradeRemark,-15} |");
            }
            Console.WriteLine($"| {"---------------------------------------------------------------------",-69} | {"---------------",-15} | {"---------------",-15} |");

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine($"Total course units registered: {student.TotalCourseUnits}");
            Console.WriteLine($"Total course units passed: {student.TotalCourseUnitsPassed}");
            Console.WriteLine($"Total Weight Point: {student.TotalWeightPoints}");
            Console.WriteLine($"Your GPA: {gpa:N2}");
        }
    }
}
