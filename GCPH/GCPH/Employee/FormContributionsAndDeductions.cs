using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCPH.Employee
{
    public partial class FormContributionsAndDeductions : Form
    {
        public FormContributionsAndDeductions()
        {
            InitializeComponent();
            LoadList();
            LoadData();
        }
        Connection con = new Connection();

        private void FormContributionsAndDeductions_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtName;
        }

        private void LoadList()
        {
            dataGridView2.DataSource = null;
            con.dataGet("SELECT ID, Name FROM Employee");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            con.dataGet("SELECT Employee.Name,Deductions.* FROM Employee INNER JOIN Deductions ON Employee.ID  = Deductions.ID");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;
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
                txtSSS.Focus();
                txtEmpID.Enabled = false;
                txtName.Enabled = false;
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
                txtSSS.Focus();
                txtEmpID.Enabled = false;
                txtName.Enabled = false;
            }

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            
                    txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    txtName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                    txtSSS.Focus();
                    txtEmpID.Enabled = false;
                    txtName.Enabled = false;
               
        }

        private void ClearData()
        {
            txtEmpID.Clear();
            txtName.Clear();
            txtSSS.Clear();
            txtPagibig.Clear();
            txtPhil.Clear();
            txtBond.Clear();
            txtOther.Clear();
            txtHairnet.Clear();
            txtMedical.Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpID.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpID, "ID Recquired");
            }
            else if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpID, "Name Recquired");
            }
            else if (string.IsNullOrEmpty(txtSSS.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSSS, "SSS contribution Recquired");
            }
            else if (string.IsNullOrEmpty(txtPagibig.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPagibig, "Pag-ibig contribution Recquired");
            }
            else if (string.IsNullOrEmpty(txtPhil.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhil, "Philhealth contribution Recquired");
            }
            else if (string.IsNullOrEmpty(txtBond.Text))
            {
                txtBond.Text = "0";
            }
            else if (string.IsNullOrEmpty(txtOther.Text))
            {
                txtOther.Text = "0";
            }
            else if (string.IsNullOrEmpty(txtMedical.Text))
            {
                txtMedical.Text = "0";
            }
            else if (string.IsNullOrEmpty(txtHairnet.Text))
            {
                txtHairnet.Text = "0";
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
            con.dataGet("Select 1 from Deductions WHERE ID ='" + empID + "'");
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
                    con.dataSend("INSERT INTO Deductions (ID, SSS, Pagibig, Philhealth, Bond_Deposit, Medical, Other_Deduction, [Facemask/Hairnet]) VALUES ('"+txtEmpID.Text+"','"+txtSSS.Text+"','"+txtPagibig.Text+"','"+txtPhil.Text+"','"+txtBond.Text+"','"+txtMedical.Text+"','"+txtOther.Text+"','"+txtHairnet.Text+"')");
                    MessageBox.Show("Record Save Successfully", "Message", MessageBoxButtons.OK);
                    ClearData();
                    LoadData();
                }
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpID.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtSSS.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPagibig.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtPhil.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtBond.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtMedical.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtOther.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtHairnet.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtSSS.Focus();
            txtEmpID.Enabled = false;
            txtName.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                con.dataGet("SELECT TOP 10 Employee.Name,Deductions.* FROM Employee INNER JOIN Deductions ON Employee.ID  = Deductions.ID WHERE Name LIKE '" + txtSearch.Text + "%'");
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
                    txtName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtEmpID.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtSSS.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtPagibig.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    txtPhil.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    txtBond.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    txtMedical.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    txtOther.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    txtHairnet.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    txtSSS.Focus();
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnRemove.Enabled = true;
                    txtEmpID.Enabled = false;
                    txtName.Enabled = false;
                    txtSearch.Clear();
                }


            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    con.dataSend("UPDATE Deductions SET SSS ='"+txtSSS.Text+"', Pagibig ='"+txtPagibig.Text+"', Philhealth ='"+txtPhil.Text+"', Bond_Deposit ='"+txtBond.Text+"', Medical ='"+txtMedical.Text+"', Other_Deduction ='"+txtOther.Text+"', [Facemask/Hairnet] ='"+txtHairnet.Text+"'");
                    MessageBox.Show("Successfully uptaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearData();
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    btnRemove.Enabled = false;
                    txtEmpID.Enabled = true; txtName.Enabled = true;
                }

            }  
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("DELETE FROM Deductions WHERE ID = '"+txtEmpID.Text+"'");
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;
                txtEmpID.Enabled = true;
                txtName.Enabled = true;
            }
        }


    }
}
