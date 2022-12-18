using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace GCPH.Employee
{
    public partial class FormEmployeeAttendance : Form
    {
        public FormEmployeeAttendance()
        {
            InitializeComponent();
            LoadList();
            groupBox1.Enabled = false;
        }
        Connection con = new Connection();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorksheet;
            Microsoft.Office.Interop.Excel.Range xlRange;

            int xlRow;
            string fileName;

            openFileDialog1.Filter = "Excel Office | *.xls; *.xlsx";
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;

            if(fileName!=  string.Empty) 
            { 
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkbook = xlApp.Workbooks.Open(fileName);
                xlWorksheet= xlWorkbook.Worksheets["Abnormal"];
                xlRange = xlWorksheet.UsedRange;
                int i=0;

                for (xlRow = 6; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    i++;
                    dataGridView1.Rows.Add(i, xlRange.Cells[xlRow,1].Text, xlRange.Cells[xlRow, 2].Text, xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text, xlRange.Cells[xlRow, 6].Text, xlRange.Cells[xlRow, 7].Text, xlRange.Cells[xlRow, 8].Text, xlRange.Cells[xlRow, 9].Text);
                }
                xlWorkbook.Close();
                xlApp.Quit();
            }
        }
        
        private void LoadList()
        {
            dataGridView2.DataSource = null;
            con.dataGet("SELECT ID, Name FROM Employee");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text))
            {
                LoadList();
            }
            else
            {

                con.dataGet("SELECT TOP 10 ID,Name FROM Employee WHERE ID LIKE '" + txtEmpID.Text + "%'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView2.DataSource = dt;

            }
        }

        private void txtEmpID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtEmpID.Enabled = false;
                txtName.Enabled = false;
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                LoadList();
            }
            else
            {

                con.dataGet("SELECT TOP 10 ID,Name FROM Employee WHERE Name LIKE '" + txtName.Text + "%'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView2.DataSource = dt;

            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                txtEmpID.Enabled = false;
                txtName.Enabled = false;
            }
        }
    }
}
