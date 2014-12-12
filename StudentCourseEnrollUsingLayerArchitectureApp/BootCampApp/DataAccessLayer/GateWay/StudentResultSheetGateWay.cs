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
    class StudentResultSheetGateWay
    {


         private SqlConnection connection;
       
         public StudentResultSheetGateWay()
         {
            string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }

         List<StudentResultSheet> resultSheetList = new List<StudentResultSheet>();
        public List<StudentResultSheet> ShowStudentResultSheet(string aStudentRegNo)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM ResultEntry_t WHERE Student_RegNo=@StudentRegNo");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@StudentRegNo", aStudentRegNo));
            SqlDataReader aReader = command.ExecuteReader();

            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    StudentResultSheet aStudentResultSheet = new StudentResultSheet();
                    aStudentResultSheet.CourseTitle = aReader[1].ToString();
                    aStudentResultSheet.Score = Convert.ToSingle(aReader[2]);
                    resultSheetList.Add(aStudentResultSheet);
                }
            }
            connection.Close();
         return  resultSheetList;
        }
    }
}
