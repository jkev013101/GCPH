using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCPH.User
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(txtUsername.Text.Length > 0)
                {
                    txtOldpassword.Focus();
                }
                else
                {
                    txtUsername.Focus();
                }
            }
        }

        private void txtOldpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtOldpassword.Text.Length > 0)
                {
                    txtNewpassword.Focus();
                }
                else
                {
                    txtOldpassword.Focus();
                }
            }
        }

        private void txtNewpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNewpassword.Text.Length > 0)
                {
                    txtCfrmpassword.Focus();
                }
                else
                {
                    txtNewpassword.Focus();
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to change your Password","Message",MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Connection con = new Connection();
                con.dataGet("SELECT 1 FROM [User] WHERE username = '"+txtUsername.Text+"' AND password = '"+txtOldpassword.Text+"'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);

                if (dt.Rows.Count>0)
                {
                    if (txtNewpassword.Text == txtCfrmpassword.Text) 
                    {
                        if (txtNewpassword.Text.Length > 3)
                        {
                            con.dataSend("UPDATE [User] SET password ='"+txtNewpassword.Text+"' WHERE username = '"+txtUsername.Text+"'");
                            MessageBox.Show("Password Successfully Changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Clear();
                            txtOldpassword.Clear();
                            txtNewpassword.Clear();
                            txtCfrmpassword.Clear();
                            errorProvider1.Clear();

                        }
                        else
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtNewpassword, "Password Minimum of 4 Characters Recquired");
                        }
                    }
                    else
                    {
                        errorProvider1.Clear();
                        errorProvider1.SetError(txtNewpassword, "Password does not match");
                        errorProvider1.SetError(txtCfrmpassword, "Password does not match");
                    }
                }
                else
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtUsername, "Please Check Username and Password");
                    errorProvider1.SetError(txtOldpassword, "Please Check Username and Password");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUsername;
        }
    }
}
