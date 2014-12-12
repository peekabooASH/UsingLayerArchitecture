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
    class StudentGateWay
    {
        private SqlConnection connection;
      
        public StudentGateWay()
        {
            string conn = ConfigurationManager.ConnectionStrings["BootCamp"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = conn;
        }
        public Dictionary<string ,Student> SearchReg(string regNo)
        {
            Dictionary<string ,Student> aStudentInfo=new Dictionary<string,Student>();
           
                connection.Open();
                string query = string.Format("SELECT * FROM t_Student WHERE Student_RegNo=@aNewID");
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add(new SqlParameter("@aNewID", regNo));

                SqlDataReader aReader = command.ExecuteReader();
                if (aReader.HasRows)
                {
                    while (aReader.Read())
                    {
                       Student aStudent=new Student(); 
                       aStudent.RegNo = aReader[0].ToString();
                       aStudent.Name = aReader[1].ToString();
                       aStudent.Email = aReader[2].ToString();
                       aStudentInfo.Add(regNo,aStudent);
                    }
                }
                connection.Close();
                return aStudentInfo;
           
        }
         public bool HasThisStudent(string RegNO)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Student WHERE Student_RegNo=@aNewID");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add(new SqlParameter("@aNewID", RegNO));
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

    }
}
