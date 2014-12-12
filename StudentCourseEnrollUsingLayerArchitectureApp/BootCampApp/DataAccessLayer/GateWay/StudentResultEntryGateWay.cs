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
    class StudentResultEntryGateWay
    {
        private SqlConnection connection;
        public StudentResultEntryGateWay()
         {
            string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }
        public void ResultEntry(ResultEntry aResultEntry)
        {
           
                connection.Open();
                string query = string.Format("INSERT INTO ResultEntry_t VALUES(@NewRegNo,@NewCourseTitle,@NewScore,@Newdate )");
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@NewRegNo", aResultEntry.RegNo));
                command.Parameters.Add(new SqlParameter("@NewCourseTitle", aResultEntry.CourseTitle));
                command.Parameters.Add(new SqlParameter("@NewScore", aResultEntry.Score));
                command.Parameters.Add(new SqlParameter("@Newdate", aResultEntry.date));

                SqlDataReader aReader = command.ExecuteReader();
                connection.Close();
            
        }

       public bool HasThisResultEntry(string CourseTitle, string Student_RegNo)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM ResultEntry_t  WHERE Course_Title=@NewCourse And  Student_RegNo=@StudentRegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@NewCourse", CourseTitle));
            command.Parameters.Add(new SqlParameter("@StudentRegNo", Student_RegNo));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }


       public bool HasThisCourseEnrolled(string CourseTitle, string Student_RegNo)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM StudentEnrollCourse  WHERE Course_Title=@NewCourse And  Student_RegNo=@StudentRegNo");
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
