using System;
using static System.Console;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;
using Figgle;
using RocketGPA.Core;
using RocketGPA.Models;

namespace RocketGPA.UI
{
    public class UserInterface
    {
        /// <summary>
        /// Run the application
        /// </summary>
        public static void Run()
        {
            WriteLine(FiggleFonts.Slant.Render("Rocket GPA")); // draw logo on console

            WriteLine("Welcome! To calculate your GPA, enter your course details in this format:");
            WriteLine("\tcourse-code course-unit course-score, course-code course-unit course-score");
            WriteLine("\tMaximum Course Unit: 9 Maximum Total Course Units: 45\n");

            WriteLine("\tEg: MTH101 5 74, ENG103 4 60, EDU105 4 56\n");

            var student = new Student();
            var studentService = new StudentService();

            var matcher = new Regex(@"^[A-Z]{2,3}[0-9]{3}\s\d\s([0-9]|[1-9][0-9]|100)\z");

            bool invalid = true;
            bool checking = true;

            while (checking)
            {
            start:
                while (invalid)
                {
                    Write("\nCourse Details: ");
                    string[] input = ReadLine().Split(", ");
                    int countInvalid = 0;

                    foreach (string entry in input)
                    {
                        if (!matcher.IsMatch(entry))
                        {
                            WriteLine($"Wrong input format for {entry}. Eg: MTH101 5 74, ENG103 4 60, EDU105 4 56");
                            countInvalid++;
                            continue;
                        }
                    }

                    if (countInvalid == 0)
                    {
                        try
                        {
                            studentService.AddCourses(student, input);
                            invalid = false;
                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine($"\n{e.Message}");
                            student = new Student();
                            goto start;
                        }
                    }
                }

                // pause for dramatic effect
                WriteLine("\nCalculating your GPA. Please wait ...\n");
                Thread.Sleep(3000);

                GradingService.Calculate(student);

                Write("\nCheck again? (Y/N): ");
                string answer = ReadLine().ToUpper();

                if (answer == "Y")
                {
                    student = new Student();
                    invalid = true;
                    goto start;
                }
                else
                {
                    checking = false;
                }
            }
        }
    }
}
