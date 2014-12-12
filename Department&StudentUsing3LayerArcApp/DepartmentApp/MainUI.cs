using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartmentApp
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void studentButton_Click(object sender, EventArgs e)
        {
            StudentUI aStudentUi = new StudentUI();
            aStudentUi.ShowDialog();
        }

        private void departmentButton_Click(object sender, EventArgs e)
        {
            DepartmentUI aDepartmentUi = new DepartmentUI();
            aDepartmentUi.ShowDialog();
        }
    }
}
