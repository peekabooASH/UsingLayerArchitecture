using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.BusinessLogicLayer
{
    class ResultBll
    {
        StudentResultSheetBll aResultSheetBll;
        public float aAverage;
        public char aGrade;

       public List<StudentResultSheet> aStudentResult;
       public ResultBll(string aStudentRegNo):this()
        {
            aStudentResult = aResultSheetBll.ShowStudentResultSheet(aStudentRegNo);
            aAverage = aResultSheetBll.GetAverage();
            aGrade = aResultSheetBll.grade;
            
        }
       public ResultBll()
       {
           aResultSheetBll = new StudentResultSheetBll();
       }

     }
}
