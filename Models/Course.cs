using RocketGPA.Core;
using RocketGPA.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketGPA.Models
{
    public class Course
    {
        public string CourseCode;
        public int CourseUnits;
        public int StudentScore;
        public Grades StudentGrade;
        public string StudentGradeRemark;
        public int WeightPoint;

        public Course(string courseCode, int courseUnit, int studentScore)
        {
            CourseCode = courseCode;
            CourseUnits = courseUnit;
            StudentScore = studentScore;

            CourseService.CheckGrade(this, StudentScore);

            WeightPoint = CourseUnits * (int)StudentGrade;
        }
    }
}
