using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GCPH.Employee
{
    public partial class FormEmployeeData : Form
    {
        public FormEmployeeData()
        {
            InitializeComponent();
            LoadData();
            txtEmpId.Enabled= false;
            txtAge.Enabled= false;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            cmbEmpType.SelectedIndex= 0;
            cmbStatus.SelectedIndex = 0;
            cmbSex.SelectedIndex = 0;
            cmbStatus.Enabled = false;
        }
        Connection con = new Connection();

        private void FormEmployeeRegister_Load(object sender, EventArgs e)
        {
            
            this.ActiveControl = txtEmpName;
            txtEmpId.Enabled = false;
        }

        private void txtEmpName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtEmpName.Text.Length > 0)
                {
                    txtContact.Focus();
                }
                else
                {
                    txtEmpName.Focus();
                }
            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtContact.Text.Length > 0)
                {
                    txtAddress.Focus();
                }
                else
                {
                    txtContact.Focus();
                }
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar !=Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                if(txtAddress.Text.Length > 0)
                {
                    cmbSex.Focus();
                }
                else
                {
                    txtAddress.Focus();
                }
            }
        }

        private void cmbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbEmpType.Focus();
            }
            else
            {
                cmbSex.Focus();
            }
        }

        private void cmbEmpType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDob.Focus();
            }
            else
            {
                cmbEmpType.Focus();
            }
        }

        private void dtpDob_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                cmbStatus.Focus();
            }
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Today.Year - dtpDob.Value.Year;
            txtAge.Text = age.ToString();
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTin.Focus();
            }
            else
            {
                cmbStatus.Focus();
            }
        }

        
        private void txtTin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtTin.Text.Length > 0)
                {
                    txtPagibig.Focus();
                }
                else
                {
                    txtTin.Focus();
                }
            }
        }

        private void txtTin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPagibig_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtPagibig.Text.Length > 0)
                {
                    txtSSS.Focus();
                }
                else
                {
                    txtPagibig.Focus();
                }
            }
        }

        private void txtPagibig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtSSS_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtSSS.Text.Length > 0)
                {
                    txtPhilhealth.Focus();
                }
                else
                {
                    txtSSS.Focus();
                }
            }
        }

        private void txtSSS_KeyPress(object sender, KeyPressEventArgs e)
        {
                    if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
                    {
                        e.Handled = true;
                    }
        }

        private void txtPhilhealth_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtPhilhealth.Text.Length > 0)
                {
                    dtpHired.Focus();
                }
                else
                {
                    txtPhilhealth.Focus();
                }
            }
        }

        private void txtPhilhealth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }
        //a validation boolean method where if the user enter a null will show an error or out of bounds
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEmpName, "Name Recquired");
            }
            else if (string.IsNullOrEmpty(txtContact.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtContact, "Contact Number Recquired");
            }
            else if (txtContact.Text.Length < 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtContact, "Contact Number Maximum of 11 didgits and  Minimum of 11 Digits Recquired");
            }
            else if (txtContact.Text.Length > 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtContact, "Contact Number Maximum of 11 didgits and  Minimum of 11 Digits Recquired");
            }
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAddress, "Address Recquired");
            }
            else if (string.IsNullOrEmpty(cmbSex.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbSex, "Sex Recquired");
            }
            else if (string.IsNullOrEmpty(cmbEmpType.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cmbEmpType, "Employee Type Recquired");
            }
            else if (string.IsNullOrEmpty(txtAge.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAge, "Age Recquired");
            }
            else if (int.Parse(txtAge.Text) <= 17)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAge, "Age Recquired is 18");
            }
            
            else if (string.IsNullOrEmpty(txtTin.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTin, "TIN Number Recquired");
            }
            else if (txtTin.Text.Length < 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTin, "TIN Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else if (txtTin.Text.Length > 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTin, "TIN Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else if (string.IsNullOrEmpty(txtPagibig.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPagibig, "Pag-ibig Number Recquired");
            }
            else if (txtPagibig.Text.Length < 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPagibig, "Pag-ibig Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else if (txtPagibig.Text.Length > 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPagibig, "Pag-ibig Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else if (string.IsNullOrEmpty(txtSSS.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSSS, "SSS Number Recquired");
            }
            else if (txtSSS.Text.Length < 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSSS, "SSS Number Maximum of 10 didgits and  Minimum of 10 Digits Recquired");
            }
            else if (txtSSS.Text.Length > 10)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSSS, "SSS Number Maximum of 10 didgits and  Minimum of 10 Digits Recquired");
            }
            else if (string.IsNullOrEmpty(txtPhilhealth.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhilhealth, "Philhealth Number Recquired");
            }
            else if (txtPhilhealth.Text.Length < 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhilhealth, "Philhealth Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else if (txtPhilhealth.Text.Length > 12)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhilhealth, "Philhealth Number Maximum of 12 didgits and  Minimum of 12 Digits Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result= true;
            }
            return result;
        }

        //method for clearing data on the fields
        private void ClearData()
        {
            txtEmpId.Clear();
            txtEmpName.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            cmbSex.SelectedIndex= 0;
            cmbEmpType.SelectedIndex = 0;
            dtpDob.Value = DateTime.Now;
            txtAge.Clear();
            txtTin.Clear();
            txtPagibig.Clear();
            txtSSS.Clear();
            txtPhilhealth.Clear();
            dtpHired.Value = DateTime.Now;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            cmbStatus.Enabled = false;
            cmbDepartment.SelectedIndex = 0;
        }
        
        //methods for checking if the record of the employee already exists
        private bool ifEmployeeContactExists(string contact)
        {
            con.dataGet("Select 1 from [Employee] where [Contact] = '" + contact + "'");
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

        private bool ifEmployeeTinExists(string tin)
        {
            con.dataGet("Select 1 from [Employee] where [TIN] = '" + tin + "'");
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

        private bool ifEmployeePagibibgExists(string pagibig)
        {
            con.dataGet("Select 1 from [Employee] where [Pagibig] = '" +pagibig+ "'");
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
        private bool ifEmployeeSSSExists(string sss)
        {
            con.dataGet("Select 1 from [Employee] where [SSS] = '" + sss + "'");
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

        private bool ifEmployeePhilhealthExists(string philhealth)
        {
            con.dataGet("Select 1 from [Employee] where [Philhealth] = '" + philhealth + "'");
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
                
                    if (ifEmployeeContactExists(txtContact.Text))
                    {
                        
                        MessageBox.Show("Record of the Employee Contact already exists");

                    }
                    else 
                    {
                        if (ifEmployeeTinExists(txtTin.Text))
                        {
                            MessageBox.Show("Record of the Employee TIN Number already exists");
                        }

                        else
                        {

                            if (ifEmployeePagibibgExists(txtPagibig.Text)) 
                            {
                                MessageBox.Show("Record of the Employee Pagibig Number already exists");
                            }
                            else
                            {
                                if (ifEmployeeSSSExists(txtSSS.Text))
                                {
                                    MessageBox.Show("Record of the Employee SSS Number already exists");
                                }
                                else 
                                {
                                    if(ifEmployeePhilhealthExists(txtPhilhealth.Text))
                                    {
                                        MessageBox.Show("Record of the Employee Philhealth Number already exists");
                                    }
                                    else
                                    {
                             
                                    con.dataSend("INSERT INTO Employee (Name, Contact, Address, Birthday, TIN, Pagibig, SSS, Philhealth, Date_Hired, EmployeeType, Sex, Age, Status, Department) VALUES ('"+txtEmpName.Text+"','"+txtContact.Text+"','"+txtAddress.Text+"','"+dtpDob.Text+"','"+txtTin.Text+"','"+txtPagibig.Text+"','"+txtSSS.Text+"','"+txtPhilhealth.Text+"','"+dtpHired.Text+"','"+cmbEmpType.Text+"','"+cmbSex.Text+"','"+txtAge.Text+"','"+cmbStatus.Text+"','"+cmbDepartment.Text+"')");
                                    MessageBox.Show("Record Save Successfully", "Message", MessageBoxButtons.OK);
                                    ClearData();
                                    LoadData();
                                    
                                    }
                                }
                            }
                        }
                    }
                
            }

        }

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            con.dataGet("SELECT ID, Name, Contact, Address, Birthday, Age, Sex, TIN, Pagibig, SSS, Philhealth, Date_Hired, EmployeeType, Status, Department FROM     Employee");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtTin.Enabled= false;
            txtPagibig.Enabled= false;
            txtSSS.Enabled= false;
            txtPhilhealth.Enabled= false;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Validation())
                {

                    string contact = null;
                    con.dataSend("UPDATE Employee SET Contact ='"+contact+"' WHERE ID = '"+txtEmpId.Text+"'");
                        if (ifEmployeeContactExists(txtContact.Text))
                        {
                            MessageBox.Show("Record of the Employee Contact already exists");
                        }
                        else
                        {


                            con.dataSend("UPDATE Employee SET Name ='"+txtEmpName.Text+"', Contact ='"+txtContact.Text+"', Address ='"+txtAddress.Text+"', EmployeeType ='"+cmbEmpType.Text+"', Age ='"+txtAge.Text+"', Status = '"+cmbStatus.Text+"', Department = '"+cmbDepartment.Text+"' WHERE  ID = '" + txtEmpId.Text + "'");
                            MessageBox.Show("Successfully uptaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                            ClearData();
                            btnSave.Enabled = true;
                            btnUpdate.Enabled = false;
                            btnRemove.Enabled = false;
                            txtPhilhealth.Enabled = true;
                            txtPagibig.Enabled = true;
                            txtSSS.Enabled = true;
                            txtTin.Enabled = true;
                            dtpDob.Enabled = true;
                            cmbSex.Enabled = true;
                            dtpHired.Enabled = true;
                        }     

                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            txtTin.Enabled = false;
            txtPagibig.Enabled = false;
            txtSSS.Enabled = false;
            txtPhilhealth.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Remove", MessageBoxButtons.YesNo);

            if(dialogResult == DialogResult.Yes)
            {
            
                con.dataSend("DELETE FROM Employee WHERE ID = '"+txtEmpId.Text+"'");
                MessageBox.Show("Successfully removed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;
                txtPhilhealth.Enabled = true;
                txtPagibig.Enabled = true;
                txtSSS.Enabled = true;
                txtTin.Enabled = true;
                cmbSex.Enabled = true;
                dtpDob.Enabled= true;
                dtpHired.Enabled = true;
            }
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtEmpId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtContact.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtAddress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dtpDob.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtAge.Text= dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cmbSex.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtTin.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            txtPagibig.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtSSS.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            txtPhilhealth.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            dtpHired.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            cmbEmpType.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
            cmbStatus.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            cmbDepartment.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnRemove.Enabled = true;
            txtTin.Enabled = false;
            txtPagibig.Enabled = false;
            txtSSS.Enabled = false;
            txtPhilhealth.Enabled = false;
            txtSearch.Clear();
            dtpDob.Enabled = false;
            cmbStatus.Enabled = true;
            cmbSex.Enabled = false;
            dtpHired.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            txtPhilhealth.Enabled = true;
            txtPagibig.Enabled = true;
            txtSSS.Enabled = true;
            txtTin.Enabled = true;
            dtpDob.Enabled = true;
            cmbSex.Enabled = true;
            dtpHired.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                //con.dataGet("SELECT TOP 10 EmpId, Name, Contact, Address, Birthday, Age, Sex, TIN, Pagibig, SSS, Philhealth, Date_Hired, EmployeeType, Status FROM Employee WHERE EmpId LIKE '" + txtSearch.Text + "%'");
                con.dataGet("SELECT TOP 10 ID, Name, Contact, Address, Birthday, Age, Sex, TIN, Pagibig, SSS, Philhealth, Date_Hired, EmployeeType, Status, Department FROM Employee WHERE Name LIKE '" + txtSearch.Text + "%'");
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
                    txtEmpId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    txtEmpName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    txtContact.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    txtAddress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                    dtpDob.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    txtAge.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                    cmbSex.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                    txtTin.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    txtPagibig.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    txtSSS.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    txtPhilhealth.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    dtpHired.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    cmbEmpType.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    cmbStatus.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    cmbDepartment.Text = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnRemove.Enabled = true;
                    txtTin.Enabled = false;
                    txtPagibig.Enabled = false;
                    txtSSS.Enabled = false;
                    txtPhilhealth.Enabled = false;
                    txtSearch.Clear();
                    cmbStatus.Enabled = true;
                    dtpDob.Enabled = false;
                    cmbSex.Enabled = false;
                    dtpHired.Enabled = false;

                }
                
            }
        }
    }
}
