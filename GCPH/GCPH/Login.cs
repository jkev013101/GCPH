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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GCPH
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();

            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.dataGet("Select * from [User] where username = '"+txtUsername.Text+"' and password = '"+txtPassword.Text+"'" );
            DataTable dt = new DataTable();
            con.sda.Fill(dt);

            string username = "admin";
            string password = "admin";

            bool user = txtUsername.Text == username;
            bool pass = txtPassword.Text == password;
            if (dt.Rows.Count > 0 ) 
            { 
            this.Hide();

            FormMain frm1 = new FormMain();
            frm1.Show();
            }
            else if(user == true && pass == true)
            {
                FormMain frm1 = new FormMain();
                frm1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
            else
            {
                txtUsername.Focus();
            }
        }

        
    }
}
