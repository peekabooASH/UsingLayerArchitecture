using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCampApp.DataAccessLayer.DataAccessObject
{
    class ResultEntry
    {
          
        public string RegNo { get; set; }
        public string CourseTitle { get; set; }
        public float Score { get; set; }
        public DateTime date { get; set; }
        public ResultEntry()
        {
        }
    }
}
