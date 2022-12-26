using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GCPH.Employee
{
    public partial class FormEmployeeSalaryDetails : Form
    {
        public FormEmployeeSalaryDetails()
        {
            InitializeComponent();
            LoadData();
            LoadList();
        }
        Connection con = new Connection();

        private void txtEmpID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    txtEmpName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                    txtRate.Focus();
                    txtEmpID.Enabled= false;
                    txtEmpName.Enabled= false;
                }
            }
        }

        private void txtEmpID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpID.Text))
            {
                LoadList();
            }
            else
            {

            con.dataGet("SELECT TOP 10 ID,Name FROM Employee WHERE ID LIKE '"+txtEmpID.Text+"%'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView2.DataSource= dt;
            
            }
        }

        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar !='.')
            {
                e.Handled = true;
            }
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                LoadList();
            }
            else
            {
                con.dataGet("SELECT TOP 10 ID,Name FROM Employee WHERE Name LIKE '" + txtEmpName.Text + "%'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void txtEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    txtEmpName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                    txtRate.Focus();
                    txtEmpID.Enabled = false;
                    txtEmpName.Enabled = false;
                }
            }
        }

        private void FormEmployeeSalaryDetails_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtEmpID;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            

        }

        

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRph.Focus();
            }
        }

        private void txtRph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOTRate.Focus();
            }
        }
        
        private void txtOTRate_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtOTRate.Text.Length > 0)
                {
                    btnSave.Focus();
                }

            }
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpID.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpID, "ID Recquired");
            }
            else if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpName, "Name Recquired");
            }
            else if (string.IsNullOrEmpty(txtRate.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRate, "Rate Recquired");
            }
            else if (string.IsNullOrEmpty(txtRph.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRph, "Rate Per Hour Recquired");
            }
            else if (string.IsNullOrEmpty(txtOTRate.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOTRate, "Overtime Rate Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;

        }

        private bool ifEmployeeExists(string empID)
        {
            con.dataGet("Select 1 from EmpSalary WHERE ID ='"+empID+"'");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ClearData()
        {
            txtEmpID.Clear();
            txtEmpName.Clear();
            txtRate.Clear();
            txtRph.Clear();
            txtOTRate.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            txtSearch.Clear();
            txtEmpID.Enabled = true;
            txtEmpName.Enabled = true;
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            con.dataGet("SELECT Employee.Name,EmpSalary.* FROM Employee INNER JOIN EmpSalary ON Employee.ID  = EmpSalary.ID");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void LoadList()
        {
            dataGridView2.DataSource = null;
            con.dataGet("SELECT ID, Name FROM Employee");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (ifEmployeeExists(txtEmpID.Text))
                {
                    MessageBox.Show("Record of the Employee Rates already exists");
                }
                else 
                { 
                    con.dataSend("INSERT INTO EmpSalary (ID, Rate, RatePerHour, OTRate) VALUES ('"+txtEmpID.Text+"','"+txtRate.Text+"','"+txtRph.Text+"','"+txtOTRate.Text+"')");
                    MessageBox.Show("Record Save Successfully", "Message", MessageBoxButtons.OK);
                    ClearData();
                    LoadData();
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.YesNo);
                if(dialogResult == DialogResult.Yes)
                {
                    con.dataSend("UPDATE EmpSalary SET Rate ='"+txtRate.Text+"', RatePerHour ='"+txtRph.Text+"', OTRate ='"+txtOTRate.Text+"' WHERE ID = '"+txtEmpID.Text+"'");
                    MessageBox.Show("Successfully uptaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearData();
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnRemove.Enabled = false;
                    

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("DELETE FROM EmpSalary WHERE ID = '"+txtEmpID.Text+"'");
                MessageBox.Show("Successfully Removed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;

            }
        }

        //keypress event making the text boxes accept numeric keys only
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtRph_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtOTRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            txtRate.Focus();
            txtEmpID.Enabled = false;
            txtEmpName.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtEmpName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpID.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtRate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtRph.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtOTRate.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnRemove.Enabled = true;
            txtEmpID.Enabled = false;
            txtEmpName.Enabled = false;
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                con.dataGet("SELECT TOP 10 Employee.Name,EmpSalary.* FROM Employee INNER JOIN EmpSalary ON Employee.ID  = EmpSalary.ID WHERE Name LIKE '" + txtSearch.Text + "%'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    txtEmpName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtEmpID.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtRate.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtRph.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    txtOTRate.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnRemove.Enabled = true;
                    txtEmpID.Enabled = false;
                    txtEmpName.Enabled = false;
                    txtSearch.Clear();
                }
            }
        }
        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRate.Text))

            {
                float rate;
                rate = float.Parse(txtRate.Text);

                //calculating the rate per hour
                double rph = rate / 8;
                txtRph.Text = (Math.Truncate(rph * 100) / 100).ToString();


                //calculating the OT rate
                double OTRate = rate / 8 * 0.25;
                txtOTRate.Text = (Math.Truncate(OTRate * 100) / 100).ToString();
            
            }
            else if (string.IsNullOrEmpty(txtRate.Text))
            {
                txtRph.Clear();
                txtOTRate.Clear();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
