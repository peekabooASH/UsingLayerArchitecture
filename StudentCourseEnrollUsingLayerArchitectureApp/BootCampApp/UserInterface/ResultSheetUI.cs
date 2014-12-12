using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BootCampApp.BusinessLogicLayer;
using BootCampApp.DataAccessLayer.DataAccessObject;

namespace BootCampApp.UserInterface
{
    public partial class ResultSheetUI : Form
    {
        public ResultSheetUI()
        {
            InitializeComponent();
            ShowStudentResultListView();

        }

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



            ResultBll aresultBll = new ResultBll(aStudent.RegNo);
            float a= aresultBll.aAverage;
            char b = aresultBll.aGrade;
            List<StudentResultSheet> resultList1 = aresultBll.aStudentResult;

            resultListView.Items.Clear();
            foreach (StudentResultSheet aValue in resultList1)
            {
                resultListView.Items.Add(new ListViewItem(new string[]{
                            aValue.CourseTitle, aValue.CourseName, aValue.Score.ToString(),aValue.Grade.ToString()
                        }));
            }
            averageTextBox.Text = a.ToString();
            gradeTextBox.Text = b.ToString();
    }
         private void ShowStudentResultListView()
        {
           resultListView.View=View.Details;
           resultListView.GridLines = true;
           resultListView.FullRowSelect = true;
           resultListView.Columns.Add("Course Title", 100);
           resultListView.Columns.Add("Course Name", 100);
           resultListView.Columns.Add("Score", 100);
           resultListView.Columns.Add("Grade", 100);
           
        }
    }
}
