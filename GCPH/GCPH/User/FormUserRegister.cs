using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCPH.User
{
    public partial class FormUserRegister : Form
    {
        public FormUserRegister()
        {
            InitializeComponent();
            txtPass.Enabled = true;
            txtUserID.Enabled= false;
            LoadData();
        }

        Connection con = new Connection();

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtName.Text.Length > 0)
                {
                    txtPhoneNumber.Focus();
                }
                else
                {
                    txtName.Focus();
                }
            }
        }

        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtPhoneNumber.Text.Length > 0)
                {
                    txtUserName.Focus();
                }
                else
                {
                    txtPhoneNumber.Focus();
                }
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUserName.Text.Length > 0)
                {
                    txtPass.Focus();
                }
                else
                {
                    txtUserName.Focus();
                }
            }
        }

        private void FormUserRegister_Load(object sender, EventArgs e)
        {
            
            this.ActiveControl = txtName;
            btnChange.Visible = false;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void ClearData()
        {
            txtUserID.Clear();
            txtUserName.Clear();
            txtName.Clear();
            txtPass.Clear();
            txtUserName.Clear();
            txtPhoneNumber.Clear();
            btnUpdate.Enabled=false;
            btnRemove.Enabled=false;
            btnSave.Enabled = true;

        }

        //a bool method that checks if the user entered a null or reach the maximum limits of the particukar data
        private bool Validation()
        {
            bool result = false;
            if(string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name Recquired");
            }
            else if(string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhoneNumber, "Phone Number Recquired");
            }
            else if (txtPhoneNumber.Text.Length < 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhoneNumber, "Phone Number Minimum of 11 Characters Recquired");
            }
            else if (txtPhoneNumber.Text.Length > 11)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhoneNumber, "Phone Number Maximum of 11 Characters Recquired");
            }
            else if(string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUserName, "Username Recquired");
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPass, "Password Recquired");
            }
            else if (txtPass.Text.Length < 4)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPass, "Password Minimum of 4 Characters Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result= true;
            }
            return result;
        }

        //bool method that checks if the username is already used
        private bool ifUserNameExists(string userName)
        {
            
            con.dataGet("Select 1 from [User] where [username] = '"+ userName +"'");
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

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            con.dataGet("SELECT UserID, username, name, phone_number FROM [User]");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (ifUserNameExists(txtUserName.Text))
                {
                    MessageBox.Show("User name already exists");
                }
                else
                {
                    
                    con.dataSend("INSERT INTO [User] (username, password, name, phone_number) VALUES ('"+txtUserName.Text+"','"+txtPass.Text+"','"+txtName.Text+"','"+txtPhoneNumber.Text+"')");
                    MessageBox.Show("Record Save Successfully");
                    ClearData();
                    LoadData();

                }
            }
        }
        
            

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "Update", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)

            {
                
                con.dataSend("UPDATE [User] SET username ='"+txtUserName.Text+"', name ='"+txtName.Text+"', phone_number ='"+txtPhoneNumber.Text+"' WHERE UserID = '"+txtUserID.Text+"'");
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;
                checkBox1.Visible = true;
                label7.Visible = true;
                txtPass.Visible = true;
                btnChange.Visible = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("DELETE FROM [User] WHERE UserID = '" + txtUserID.Text+"'");
                MessageBox.Show("Successfully removed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;
                checkBox1.Visible = true;
                label7.Visible = true;
                txtPass.Visible = true;
                btnChange.Visible = false;

            }
            
        }

        

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            } 
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            User.FormChangePassword frm = new User.FormChangePassword();
            
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }


      

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                LoadData();
            }
            else
            {
                con.dataGet("SELECT TOP 10 UserID,name,phone_number,username FROM [User] WHERE UserID LIKE '" + txtID.Text + "%'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.Rows.Count > 0) {

                txtUserID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtUserName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                
                btnChange.Visible = true;
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnRemove.Enabled = true;
                
                txtID.Clear();
                label7.Visible= false;
                txtPass.Visible= false;
                checkBox1.Visible = false;
                }


            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtUserID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtUserName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtPhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            btnChange.Visible= true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnRemove.Enabled = true;
            
            txtID.Clear();
            label7.Visible = false;
            txtPass.Visible = false;
            checkBox1.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            checkBox1.Visible = true;
            label7.Visible = true;
            txtPass.Visible = true;
            btnChange.Visible = false;
        }
    }
}
