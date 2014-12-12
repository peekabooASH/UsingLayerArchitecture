using System.Collections.Generic;
using DepartmentApp.DLL.DAO;
using DepartmentApp.DLL.DAO.View;
using DepartmentApp.DLL.GETWAY;

namespace DepartmentApp.BLL
{
    class StudentBLL
    {
       private StudentGateway aStudentGateway;

        public StudentBLL()
        {
            aStudentGateway = new StudentGateway();
        }

        public string Save(Student aStudent)
        {
            
            if (aStudent.Name == string.Empty || aStudent.Email == string.Empty || aStudent.Address == string.Empty)
            {
                return "please fill up all field";
            }
            else
            {
                if (!HasThisEmailValid(aStudent.Email))
                {
                    return aStudentGateway.Save(aStudent);
                }
                else
                {
                    return "email address already in system";
                }
            }

        }
        private bool HasThisEmailValid(string email)
        {
            return aStudentGateway.HasThisEmailValid(email);
        }

        public List<StudentDepartmentView> GetAllStudent()
        {
            return aStudentGateway.GetAllStudent();
        }
    }
}
