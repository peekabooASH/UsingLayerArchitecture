using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;
using BootCampApp.DataAccessLayer.GateWay;

namespace BootCampApp.BusinessLogicLayer
{
    class CourseBll
    {
        public CourseGateWay aCourseGateWay;
        public CourseBll()
        {
            aCourseGateWay = new CourseGateWay();
        }

        public List<Course> ShowComboBoxData()
        {
           return aCourseGateWay.ShowComboBoxData();
        }
    }
}
