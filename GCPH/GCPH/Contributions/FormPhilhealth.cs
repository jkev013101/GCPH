using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace GCPH.Contributions
{
    public partial class FormPhilhealth : Form
    {
        public FormPhilhealth()
        {
            InitializeComponent();
            LoadData();
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }
        Connection con = new Connection();

        private void LoadData()
        {
            dataGridView1.DataSource = null;
            con.dataGet("SELECT * FROM Philhealth");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ClearData()
        {
            txtCode.Clear();
            txtMin.Clear();
            txtMax.Clear();
            txtEE.Clear();
            txtER.Clear();
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code Recquired");
            }
            else if (string.IsNullOrEmpty(txtMin.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMin, "Minimum Range Recquired");
            }
            else if (string.IsNullOrEmpty(txtMax.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMax, "Maximum Range Recquired");
            }
            else if (string.IsNullOrEmpty(txtEE.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtEE, "Employee share Recquired");
            }
            else if (string.IsNullOrEmpty(txtER.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtER, "Employer share Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtEE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtER_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMin.Focus();
            }
        }

        private void txtMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMax.Focus();
            }
        }

        private void txtMax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEE.Focus();
            }
        }

        private void txtEE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtER.Focus();
            }
        }

        private void txtER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtMin.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMax.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtEE.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtER.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnRemove.Enabled = true;
            txtCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                con.dataSend("INSERT INTO Philhealth (Code, Minimum, Maximum, EE, ER) VALUES ('" + txtCode.Text + "','" + txtMin.Text + "','" + txtMax.Text + "','" + txtEE.Text + "','" + txtER.Text + "')");
                MessageBox.Show("Save Successfully", "Message", MessageBoxButtons.OK);
                ClearData();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                con.dataSend("UPDATE Philhealth SET Minimum ='" + txtMin.Text + "', Maximum ='" + txtMax.Text + "', EE ='" + txtEE.Text + "', ER ='" + txtER.Text + "' WHERE Code = '" + txtCode.Text + "'");
                MessageBox.Show("Successfully uptaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearData();
                btnSave.Enabled = true;
                btnUpdate.Enabled = false;
                btnRemove.Enabled = false;
                txtCode.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            con.dataSend("DELETE FROM Philhealth WHERE Code = '" + txtCode.Text + "'");
            LoadData();
            ClearData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            txtCode.Enabled = true;
        }
    }
}
