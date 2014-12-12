using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampApp.DataAccessLayer.DataAccessObject
{
    class StudentResultSheet
    {
        public string RegNo { get; set; }
        public string CourseTitle { get; set; }
        public string CourseName { get; set; }
        public float Score { get; set; }
        public float Average { get; set; }
        public char Grade { get; set; }

        public StudentResultSheet()
        {
        }
    }
}
