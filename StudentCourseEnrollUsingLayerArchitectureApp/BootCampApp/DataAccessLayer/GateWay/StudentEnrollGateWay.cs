using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.DataAccessLayer.GateWay
{
    class StudentEnrollGateWay
    {
        private SqlConnection connection;
         public StudentEnrollGateWay()
         {
            string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }
         public List<StudentEnroll> ShowStudentEnrollCourse(StudentEnroll studentEnroll)
         {
            List<StudentEnroll>  newlist=new List<StudentEnroll>();
          
                 connection.Open();
                 string query = string.Format("SELECT * FROM StudentEnrollCourse WHERE Student_RegNo=@StudentRegNo");
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.Add(new SqlParameter("@StudentRegNo", studentEnroll.RegNo));
                 SqlDataReader aReader = command.ExecuteReader();
                 
                 if (aReader.HasRows)
                 {
                     while (aReader.Read())
                     {
                         StudentEnroll aStudentEnroll = new StudentEnroll();
                         aStudentEnroll.RegNo = aReader[0].ToString();
                         aStudentEnroll.CourseTitle = aReader[1].ToString();
                         aStudentEnroll.date = (DateTime) aReader[2];
                         newlist.Add(aStudentEnroll);
                     }
                 }
                 connection.Close();
            return newlist;
         }
        public void EnrollStudentCourse(StudentEnroll studentEnroll)
         {
                 connection.Open();
                 string query = string.Format("INSERT INTO StudentEnrollCourse VALUES(@NewRegNo,@NewCourseTitle,@Newdate )");
                 SqlCommand command = new SqlCommand(query, connection);
                 command.Parameters.Add(new SqlParameter("@NewRegNo", studentEnroll.RegNo));
                 command.Parameters.Add(new SqlParameter("@NewCourseTitle", studentEnroll.CourseTitle));
                 command.Parameters.Add(new SqlParameter("@Newdate", studentEnroll.date));

                 SqlDataReader aReader = command.ExecuteReader();
                 connection.Close();
           
         }
        public bool HasThisStudentEnroll(string CourseTitle,string Student_RegNo)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM StudentEnrollCourse WHERE Course_Title=@NewCourse And  Student_RegNo=@StudentRegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@NewCourse", CourseTitle));
            command.Parameters.Add(new SqlParameter("@StudentRegNo", Student_RegNo));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }
    }
}
