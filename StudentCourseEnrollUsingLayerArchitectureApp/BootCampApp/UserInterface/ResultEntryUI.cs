using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BootCampApp.BusinessLogicLayer;
using BootCampApp.DataAccessLayer.DataAccessObject;
using BootCampApp.DataAccessLayer.GateWay;

namespace BootCampApp.UserInterface
{
    public partial class ResultEntryUI : Form
    {
        public ResultEntryUI()
        {
            InitializeComponent();
            ShowComboBoxData();
        }
        ResultEntry aResultEntry = new ResultEntry();
        private void findButton_Click(object sender, EventArgs e)
        {
            StudentEnroll aStudentEnroll = new StudentEnroll();
            Dictionary<string, Student> aStudentInfo = new Dictionary<string, Student>();

            StudentBll aStudentBll = new StudentBll();
            Student aStudent = new Student();
            aStudent.RegNo = regnoTextBox.Text;
            aStudentInfo = aStudentBll.SearchReg(aStudent.RegNo);
            foreach (var aStudentinfo in aStudentInfo)
            {
                regnoTextBox.Text = aStudentinfo.Key;
                nameTextBox.Text = aStudentinfo.Value.Name;
                emailTextBox.Text = aStudentinfo.Value.Email;
            }
        }

        private void viewResultSheetButton_Click(object sender, EventArgs e)
        {
            ResultSheetUI aResultSheetUi = new ResultSheetUI();
            aResultSheetUi.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StudentResultEntryBll aStudentResultEntryBll = new StudentResultEntryBll();

            Course aCourse1 = (Course) resultCourseComboBox.SelectedItem;
            DateTime date = resultDateTimePicker.Value;
            aResultEntry.RegNo = regnoTextBox.Text;
            aResultEntry.CourseTitle = aCourse1.CourseTitle.ToString();
            aResultEntry.Score = Convert.ToSingle(scoreTextBox.Text);
            aResultEntry.date = date.Date;

            string msg = aStudentResultEntryBll.ResultEntry(aResultEntry);
            MessageBox.Show(msg);
        }
        private void ShowComboBoxData()
        {

            resultCourseComboBox.DisplayMember = "CourseTitle";
            CourseBll aCourseBll = new CourseBll();
            List<Course> courses = aCourseBll.ShowComboBoxData();
            resultCourseComboBox.DataSource = courses;
        }
    }

   
}
