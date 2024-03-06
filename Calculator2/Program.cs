using ConsoleTables;
using System;

namespace Calcu
{
    // Class to represent a Course
    public class Course
    {
        public string Name { get; set; }
        //public string Code { get; set; }
        public int Unit { get; set; }
        public int Score { get; set; }
    }

    // Class to represent Grade Point and Grade Unit
    public class GradePoint
    {
        public char Grade { get; set; }
        public int GradeUnit { get; set; }
        public string Remarks { get; set; }

        public GradePoint(char grade, int unit)
        {
            switch (grade)
            {
                case 'A':
                    Grade = 'A';
                    GradeUnit = 5;
                    Remarks = "Excellent";
                    break;
                case 'B':
                    Grade = 'B';
                    GradeUnit = 4;
                    Remarks = "Very Good";
                    break;
                case 'C':
                    Grade = 'C';
                    GradeUnit = 3;
                    Remarks = "Good";
                    break;
                case 'D':
                    Grade = 'D';
                    GradeUnit = 2;
                    Remarks = "Fair";
                    break;
                case 'E':
                    Grade = 'E';
                    GradeUnit = 1;
                    Remarks = "Pass";
                    break;
                case 'F':
                    Grade = 'F';
                    GradeUnit = 0;
                    Remarks = "Fail";
                    break;
                default:
                    Grade = ' ';
                    GradeUnit = 0;
                    Remarks = "Invalid Grade";
                    break;
            }
        }
    }

    // Class to manage Grade Units and Remarks
    public class GradeManager
    {
        public GradePoint GetGradePoint(int score)
        {
            if (score >= 70 && score <= 100)
            {
                return new GradePoint('A', 5);
            }
            else if (score >= 60 && score <= 69)
            {
                return new GradePoint('B', 4);
            }
            else if (score >= 50 && score <= 59)
            {
                return new GradePoint('C', 3);
            }
            else if (score >= 45 && score <= 49)
            {
                return new GradePoint('D', 2);
            }
            else if (score >= 40 && score <= 44)
            {
                return new GradePoint('E', 1);
            }
            else
            {
                return new GradePoint('F', 0);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter your name: ");
                string studentName = Console.ReadLine();

                Console.Write("Enter number of courses: ");
                int numberOfCourses = Convert.ToInt32(Console.ReadLine());

                Course[] courses = new Course[numberOfCourses];

                for (int i = 0; i < numberOfCourses; i++)
                {
                    Course course = new Course();

                    Console.Write($"Enter course name for course {i + 1}: ");
                    course.Name = Console.ReadLine();

                    //Console.Write($"Enter course code for course {i + 1}: ");
                    //course.Code = Console.ReadLine();

                    Console.Write($"Enter course unit for course {i + 1}: ");
                    course.Unit = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"Enter score for course {i + 1}: ");
                    course.Score = Convert.ToInt32(Console.ReadLine());

                    courses[i] = course;
                }

                //Console.WriteLine("\nCourse\t\t\tUnit\tScore\tGrade\tGradeUnit\tRemarks");

                int totalQualityPoint = 0;
                int totalGradeUnit = 0;

                GradeManager gradeManager = new GradeManager();

                foreach (Course course in courses)
                {
                    GradePoint gradePoint = gradeManager.GetGradePoint(course.Score);

                    //Console.WriteLine($"{course.Name}\t\t\t{course.Unit}\t{course.Score}\t{gradePoint.Grade}\t{gradePoint.GradeUnit}\t{gradePoint.Remarks}");

                    totalQualityPoint += gradePoint.GradeUnit * course.Unit;
                    totalGradeUnit += course.Unit;
                }
                
               
                var newTable = new ConsoleTable("Course", "Course Unit", "Score", "grade", "grade Unit", "Remarks");
                foreach (Course course in courses)
                {
                    GradePoint gradePoint = gradeManager.GetGradePoint(course.Score);
                    newTable.AddRow(course.Name,course.Unit,course.Score, gradePoint.Grade, gradePoint.GradeUnit, gradePoint.Remarks);
                }
                newTable.Write();
                decimal gpa = (decimal)totalQualityPoint / totalGradeUnit;
                Console.WriteLine($"\nFinal GPA for {studentName}: {gpa:F2}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
        public void CreateTable()
        {
            
        }
    }

}
