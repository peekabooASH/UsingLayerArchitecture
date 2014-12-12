using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DepartmentApp.BLL;
using DepartmentApp.DLL.DAO;
using DepartmentApp.DLL.DAO.View;

namespace DepartmentApp
{
    public partial class StudentUI : Form
    {
        private StudentBLL aStudentBll = new StudentBLL();

        private List<StudentDepartmentView> students;

        public StudentUI()
        {
            InitializeComponent();
            ShowDataInGrid();
            ShowDepartmentComboBox();

        }

        private void ShowDepartmentComboBox()
        {
            DepartmentBLL aDepartmentBll = new DepartmentBLL();
            List<Department> departments = aDepartmentBll.GetAllDepartment();
            foreach (Department aDepartment in departments)
            {
                departmentComboBox.Items.Add(aDepartment);
            }
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.Name = nameTextBox.Text;
            aStudent.Email = emailTextBox.Text;
            aStudent.Address = addressTextBox.Text;

            Department aDepartment = (Department) departmentComboBox.SelectedItem;
            aStudent.DepartmentId = aDepartment.Id;
            string msg = aStudentBll.Save(aStudent);
            MessageBox.Show(msg);
            ShowDataInGrid();
        }

        private void ShowDataInGrid()
        {
            
            students = aStudentBll.GetAllStudent();
            studentGridView.DataSource = students;
        }

        
    }
}
