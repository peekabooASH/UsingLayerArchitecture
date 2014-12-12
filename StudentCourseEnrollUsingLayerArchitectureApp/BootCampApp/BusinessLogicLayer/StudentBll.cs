using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using BootCampApp.DataAccessLayer.GateWay;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.BusinessLogicLayer
{
    class StudentBll
    {
        public  StudentGateWay aStudentGateWay;
   
        public StudentBll()
        {
            aStudentGateWay = new StudentGateWay();
        }
        private bool HasFillUpInformation(string regNo)
        {
            if (regNo != string.Empty)
                return true;
                
          return false;
        }
    public Dictionary<string ,Student> SearchReg(string regNo) 
        {
            bool checkEmptyOrNot= HasFillUpInformation(regNo);
            Dictionary<string,Student> aStudentValue=new Dictionary<string,Student>();
           
            if (checkEmptyOrNot)
            {
                if (aStudentGateWay .HasThisStudent(regNo))
                {
                    aStudentValue = aStudentGateWay.SearchReg(regNo);

                    return aStudentValue;
                }

                regNo = "Insert Correct Value";
                aStudentValue.Add(regNo, new Student());
                return aStudentValue;

            }
            regNo = "Empty Value Inserted";
            aStudentValue.Add(regNo, new Student());
            return aStudentValue;
        }

    
    }
}
