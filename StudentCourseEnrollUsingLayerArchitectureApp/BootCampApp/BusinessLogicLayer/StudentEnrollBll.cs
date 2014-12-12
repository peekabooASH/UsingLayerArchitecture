using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;
using BootCampApp.DataAccessLayer.GateWay;

namespace BootCampApp.BusinessLogicLayer
{
    class StudentEnrollBll
    {

        private StudentEnrollGateWay aStudentEnrollGateWay;
        private  StudentGateWay aStudentGateWay=new StudentGateWay();
        public StudentEnrollBll()
        {
            aStudentEnrollGateWay = new StudentEnrollGateWay();
        }
        private bool HasFillUpEnrollInformation(StudentEnroll aStudentEnroll)
        {
            if (aStudentEnroll.RegNo != string.Empty && aStudentEnroll.CourseTitle != string.Empty)
                return true;
           
         return false;
        }
        public string EnrollStudentCourse(StudentEnroll aStudentEnroll)
        {
            if (HasFillUpEnrollInformation(aStudentEnroll))
            {
                if (!aStudentGateWay.HasThisStudent(aStudentEnroll.RegNo))
                    return "This is not correct reg number.";
                if (!aStudentEnrollGateWay.HasThisStudentEnroll(aStudentEnroll.CourseTitle, aStudentEnroll.RegNo))
                {
                          aStudentEnrollGateWay.EnrollStudentCourse(aStudentEnroll);
                          return "Enroll Succesfully.";
                }
                else
                {
                    return "Course has been taken."; 
                }
              
              
            }
            return "Fill all the information Correctlly";
        }
        public List<StudentEnroll> ShowStudentEnrollCourse(StudentEnroll aStudentEnroll)
        {
            List<StudentEnroll> newList = new List<StudentEnroll>();
            if (aStudentEnrollGateWay.HasThisStudentEnroll(aStudentEnroll.CourseTitle, aStudentEnroll.RegNo))
            {
                 newList = aStudentEnrollGateWay.ShowStudentEnrollCourse(aStudentEnroll);
                return newList;
            
            }
            return newList;
        }
    }
}
