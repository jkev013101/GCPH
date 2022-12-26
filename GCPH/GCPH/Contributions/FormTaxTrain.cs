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
    public partial class FormTaxTrain : Form
    {
        public FormTaxTrain()
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
            con.dataGet("SELECT * FROM TaxTrain");
            DataTable dt = new DataTable();
            con.sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMIn_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code Recquired");
            }
            else if (string.IsNullOrEmpty(txtMIn.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMIn, "Minimum Range Recquired");
            }
            else if (string.IsNullOrEmpty(txtMax.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMax, "Maximum Range Recquired");
            }
            else if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount Recquired");
            }
            else if (string.IsNullOrEmpty(txtRate.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtRate, "Rate Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private void ClearData()
        {
            txtCode.Clear();
            txtMIn.Clear();
            txtMax.Clear();
            txtAmount.Clear();
            txtRate.Clear();
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                con.dataSend("INSERT INTO TaxTrain (Code, Minimum, Maximum, Amount, Rate) VALUES ('"+txtCode.Text+"','"+txtMIn.Text+"','"+txtMax.Text+"','"+txtAmount.Text+"','"+txtRate.Text+"')");
                MessageBox.Show("Save Successfully", "Message", MessageBoxButtons.OK);
                ClearData();
                LoadData();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMIn.Focus();
            }
        }

        private void txtMIn_KeyDown(object sender, KeyEventArgs e)
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
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRate.Focus();
            }
        }

        private void txtRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtMIn.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMax.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtAmount.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtRate.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnRemove.Enabled = true;
            txtCode.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.dataSend("UPDATE TaxTrain SET Minimum ='"+txtMIn.Text+"', Maximum ='"+txtMax.Text+"', Amount ='"+txtAmount.Text+"', Rate ='"+txtRate.Text+ "' WHERE Code = '"+txtCode.Text+"'");
            MessageBox.Show("Successfully uptaded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
            ClearData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            txtCode.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            con.dataSend("DELETE FROM TaxTrain WHERE Code = '"+txtCode.Text+"'");
            LoadData();
            ClearData();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnRemove.Enabled = false;
            txtCode.Enabled = true;
        }
    }
}
