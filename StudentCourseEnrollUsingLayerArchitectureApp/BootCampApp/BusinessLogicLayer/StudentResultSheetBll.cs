using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;
using BootCampApp.DataAccessLayer.GateWay;

namespace BootCampApp.BusinessLogicLayer
{
    class StudentResultSheetBll
    {

         private StudentResultSheetGateWay  aStudentResultSheetGateWay;
         private int count = 0;
         private float total = 0;
        public char grade { get; set; }
        public StudentResultSheetBll()
        {
            aStudentResultSheetGateWay = new StudentResultSheetGateWay();
            count = 0;
            total = 0;
        }

        private char GradeCount(float number)
        {
            if (number >= 90) return 'A';
            if (number >= 70 && number<=89.99999) return 'B';
            if (number >= 50 && number <= 79.99999 )return 'C';
            return 'F';
        }

       public float GetAverage()
        {
            float average=total/count;
            grade = GradeCount(average);
            return average;
        }

        public List<StudentResultSheet> ShowStudentResultSheet(string aStudentRegNo)
        {
            CourseGateWay aCourseGateWay = new CourseGateWay();
            List<Course> courseList = aCourseGateWay.GetCourse(aStudentRegNo);
            List<StudentResultSheet> resultSheet = aStudentResultSheetGateWay.ShowStudentResultSheet(aStudentRegNo);
            List<StudentResultSheet> mergreResultandCourse = new List<StudentResultSheet>();
            
            
            foreach (var course in courseList)
            {
                foreach (StudentResultSheet inputResult in resultSheet)
                {
                    if (inputResult.CourseTitle == course.CourseTitle)
                    {
                        count++;
                        total += Convert.ToSingle(inputResult.Score);
                        StudentResultSheet aResult = new StudentResultSheet();
                        aResult.CourseTitle = course.CourseTitle;
                        aResult.CourseName = course.CourseName;
                        aResult.Score = inputResult.Score;
                        aResult.Grade = GradeCount(inputResult.Score);
                        mergreResultandCourse.Add(aResult);
                    }
                }
            }
         return mergreResultandCourse;
        }
   
    
    
    
    }
 }
