using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCPH
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
        }

        private void userRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.FormUserRegister frm= new User.FormUserRegister();
            frm.MdiParent= this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
        bool close = true; 
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
          if (close) 
          { 
            DialogResult result = MessageBox.Show("Are you sure want to exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                {
                    close= false;
                    Application.Exit();

                }
            else
            {
                e.Cancel = true;
            }
          }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User.FormChangePassword frm = new User.FormChangePassword();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void employeeRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.FormEmployeeData frm = new Employee.FormEmployeeData();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.FormEmployeeAttendance frm = new Employee.FormEmployeeAttendance();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            this.BackgroundImage= Properties.Resources.gcp_2;
        }

        private void employeeDeductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.FormDeductions frm = new Employee.FormDeductions();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
        private void employeeSalaryRatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.FormEmployeeSalaryDetails frm = new Employee.FormEmployeeSalaryDetails();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
        private void attendanceMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee.FormAttendanceMonitoring frm = new Employee.FormAttendanceMonitoring();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();

        }

        private void sSSContributionMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contributions.FormSSS frm = new Contributions.FormSSS();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void pagibigContributionMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contributions.FormPagibig frm = new Contributions.FormPagibig();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void philHealthContributionMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contributions.FormPhilhealth frm = new Contributions.FormPhilhealth();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void taxTrainMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contributions.FormTaxTrain frm = new Contributions.FormTaxTrain();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void biometricsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.FormBiometricsData frm = new Attendance.FormBiometricsData();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void employeeSchedulingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance.FormScheduling frm = new Attendance.FormScheduling();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}
