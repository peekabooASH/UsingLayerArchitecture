using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampApp.DataAccessLayer.DataAccessObject
{
    class StudentEnroll
    {
        
        public string RegNo { get; set; }
        public string CourseTitle { get; set; }
        public string CourseName { get; set; }
        public DateTime date { get; set; }
        public StudentEnroll()
        {
        }
    }
}
