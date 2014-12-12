using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BootCampApp.BusinessLogicLayer;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.UserInterface
{
    public partial class CourseEnrollmentUI : Form
    {
        public CourseEnrollmentUI()
        {
            InitializeComponent();
            ShowComboBoxData();
            ShowStudentEnrollCourseListView();
        }
        StudentEnroll aStudentEnroll = new StudentEnroll();
        private void findButton_Click(object sender, EventArgs e)
        {
            StudentEnroll aStudentEnroll = new StudentEnroll();
            Dictionary<string, Student> aStudentInfo = new Dictionary<string, Student>();

            StudentBll aStudentBll = new StudentBll();
            Student aStudent = new Student();
             aStudent.RegNo = regnoTextBox.Text;
             aStudentInfo = aStudentBll.SearchReg(aStudent.RegNo);
             foreach (var a in aStudentInfo)
             {
                 regnoTextBox.Text = a.Key;
                 nameTextBox.Text = a.Value.Name;
                 emailTextBox.Text = a.Value.Email;
             }
        }
        private void enrollButton_Click(object sender, EventArgs e)
        {
            StudentEnrollBll aStudentEnrollBll = new StudentEnrollBll();
          
            Course  aCourse1 =(Course) resultCourseComboBox.SelectedItem;
            DateTime date = enrollmentDateTimePicker.Value;
            aStudentEnroll.RegNo = regnoTextBox.Text;
            aStudentEnroll.CourseTitle =aCourse1.CourseTitle.ToString();
            aStudentEnroll.date = date.Date;

            string msg = aStudentEnrollBll.EnrollStudentCourse(aStudentEnroll);
            MessageBox.Show(msg);

            List<StudentEnroll> enrollList = aStudentEnrollBll.ShowStudentEnrollCourse(aStudentEnroll);
            enrollmentListView.Items.Clear();
            foreach (StudentEnroll aValue in enrollList)
            {
                enrollmentListView.Items.Add(new ListViewItem(new string[] { aValue.CourseTitle, aValue.date.ToString(),aValue.CourseName })); 
            }
        }

        private void ShowStudentEnrollCourseListView()
        {

            enrollmentListView.View = View.Details;
            enrollmentListView.GridLines = true;
            enrollmentListView.FullRowSelect = true;
            enrollmentListView.Columns.Add("Course Title", 70);
            enrollmentListView.Columns.Add("Date", 200);
        }

        private void ShowComboBoxData()
        {
            resultCourseComboBox.DisplayMember = "CourseTitle";
            resultCourseComboBox.ValueMember = "Course_Name";
            CourseBll aCourseBll = new CourseBll();
            List<Course> courses = aCourseBll.ShowComboBoxData();
            resultCourseComboBox.DataSource = courses;
        }

       
    }
}
