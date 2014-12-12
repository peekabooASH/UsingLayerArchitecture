using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.DataAccessLayer.GateWay
{
    internal class StudentResultEntryBll
    {
        private StudentResultEntryGateWay aStudentResultEntryGateWay;

        public StudentResultEntryBll()
        {
            aStudentResultEntryGateWay = new StudentResultEntryGateWay();
        }

        private bool HasFillUpResultEntryInformation(ResultEntry aResultEntry)
        {
            if (aResultEntry.RegNo != string.Empty && aResultEntry.CourseTitle != string.Empty)
                return true;
            return false;
        }

        public string ResultEntry(ResultEntry aResultEntry)
        {
            if (HasFillUpResultEntryInformation(aResultEntry))
            {

                if (!aStudentResultEntryGateWay.HasThisCourseEnrolled(aResultEntry.CourseTitle, aResultEntry.RegNo))
                {
                    return "This Student was not Enrolled with this Course.";
                    
                }
                if (!aStudentResultEntryGateWay.HasThisResultEntry(aResultEntry.CourseTitle, aResultEntry.RegNo))
                {
                    aStudentResultEntryGateWay.ResultEntry(aResultEntry);
                    return "Result has been entered Succesfully.";
                }
                else
                {
                    return "Result is Exist.";
                }

            }
            return "Fill all the information";
        }



    }
}
