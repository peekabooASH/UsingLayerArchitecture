using System.Collections.Generic;
using System.Data.SqlClient;
using DepartmentApp.DLL.DAO;
using DepartmentApp.DLL.DAO.View;

namespace DepartmentApp.DLL.GETWAY
{
    internal class StudentGateway
    {
         private SqlConnection connection;

         public StudentGateway()
         {
             string conn = @"server=TAPOS; database=AbcUniversity;integrated security=true";
             connection = new SqlConnection();
             connection.ConnectionString = conn;
         }

         public string Save(Student aStudent)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Student VALUES('{0}','{1}','{2}',{3})", aStudent.Name,
                aStudent.Email, aStudent.Address,aStudent.DepartmentId);
            SqlCommand command = new SqlCommand(query, connection);

            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "insert success";
            return "something wrong";
        }

        public bool HasThisEmailValid(string email)
        { 
            connection.Open();
            string query = string.Format("SELECT * FROM t_Student WHERE Email='{0}'", email);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool Hasrow = aReader.HasRows;
            connection.Close();
            return Hasrow;
        }

        public List<StudentDepartmentView> GetAllStudent()
        {
            connection.Open();
            string query = string.Format("SELECT * FROM View_1");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<StudentDepartmentView> students = new List<StudentDepartmentView>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {
                    StudentDepartmentView aStudentDepartmentView = new StudentDepartmentView();

                    aStudentDepartmentView.Name = aReader[0].ToString();
                    aStudentDepartmentView.Email = aReader[1].ToString();
                    aStudentDepartmentView.Address = aReader[2].ToString();
                    aStudentDepartmentView.DepName = aReader[3].ToString();
                    aStudentDepartmentView.DepCode = aReader[4].ToString();
                    students.Add(aStudentDepartmentView);
                }
            }
            connection.Close();
            return students;
        }
    }
}
