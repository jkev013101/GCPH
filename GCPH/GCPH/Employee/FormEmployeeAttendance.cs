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


namespace GCPH.Employee
{
    public partial class FormEmployeeAttendance : Form
    {
        public FormEmployeeAttendance()
        {
            InitializeComponent();
            LoadList();
            groupBox1.Enabled = false;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
        }
        Connection con = new Connection();
        
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
                groupBox1.Enabled = true;
                cmbMonth.Focus();
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
                groupBox1.Enabled = true;
                cmbMonth.Focus();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            txtEmpID.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            txtEmpID.Enabled = false;
            txtName.Enabled = false;
            groupBox1.Enabled = true;
            cmbMonth.Focus();
        }

        private void ClearData()
        {
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = 1;
            txtEmpID.Clear();
            txtName.Clear();
            txtPresent.Clear();
            txtAbsent.Clear();
            txtOT.Clear();
            txtUT.Clear();
            txtLate.Clear();
            txtSp.Clear();
            txtReg.Clear();
        }

        private bool Validation()
        {
            bool result = false;

            if (string.IsNullOrEmpty(txtPresent.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPresent, "Present days Required");
            }
            else if (string.IsNullOrEmpty(txtAbsent.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAbsent, "Absent days Recquired");
            }
            else if (string.IsNullOrEmpty(txtOT.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtOT, "Overtime hours Recquired");
            }
            else if (string.IsNullOrEmpty(txtUT.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUT, "Undertime hours Recquired");
            }
            else if (string.IsNullOrEmpty(txtReg.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtReg, "Regular holidays Recquired");
            }
            else if (string.IsNullOrEmpty(txtSp.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSp, "Special holidays Recquired");
            }
            else
            {
                errorProvider1.Clear();
                result = true;
            }
            return result;
        }

        private void FormEmployeeAttendance_Load(object sender, EventArgs e)
        {
            cmbYear.Items.Add((DateTime.Now.Year) - 1);
            cmbYear.Items.Add((DateTime.Now.Year));
            cmbYear.Items.Add((DateTime.Now.Year) + 1);
            cmbYear.SelectedItem = cmbYear.Items[1];
        }

        private void txtPresent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtAbsent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtUT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtLate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtSp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtPresent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAbsent.Focus();
            }
        }

        private void txtAbsent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtAbsent.Text))
                {
                    txtAbsent.Text = "0";
                }
                txtOT.Focus();
            }
        }

        private void txtOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOT.Text))
                {
                    txtOT.Text = "0";
                }
                txtUT.Focus();
            }
        }

        private void txtUT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtUT.Text))
                {
                    txtUT.Text = "0";
                }
                txtLate.Focus();
            }
        }

        private void txtLate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtLate.Text))
                {
                    txtLate.Text = "0";
                }
                txtReg.Focus();
            }
        }

        private void txtReg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtReg.Text))
                {
                    txtReg.Text = "0";
                }
                txtSp.Focus();
            }
        }

        private void txtSp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtSp.Text))
                {
                    txtSp.Text = "0";
                }
                btnSave.Focus();
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMonth.SelectedIndex != -1)
            {
                con.dataGet("SELECT * FROM Attendance WHERE ID = '"+txtEmpID.Text+"' AND Month = '"+cmbMonth.Text+"' AND Year = '"+cmbYear.Text+"'");
                DataTable dt = new DataTable();
                con.sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    txtPresent.Text = dt.Rows[0]["PresentDays"].ToString();
                    txtAbsent.Text = dt.Rows[0]["Absents"].ToString();
                    txtReg.Text = dt.Rows[0]["RegularHoliday"].ToString();
                    txtSp.Text = dt.Rows[0]["SpecialHoliday"].ToString();
                    txtOT.Text = dt.Rows[0]["OvertimeHours"].ToString();
                    txtUT.Text = dt.Rows[0]["UndertimeHours"].ToString();
                    txtLate.Text = dt.Rows[0]["LateHours"].ToString();
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = true;
                }
                else
                {
                    txtPresent.Text = "";
                    txtAbsent.Text = "";
                    txtReg.Text = "";
                    txtSp.Text = "";
                    txtOT.Text = "";
                    txtUT.Text = "";
                    txtLate.Text = "";
                    btnSave.Enabled = false;
                    btnEdit.Enabled = true;
                    btnRemove.Enabled = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                con.dataSend("INSERT INTO Attendance (ID, Month, Year, PresentDays, Absents, RegularHoliday, SpecialHoliday, OvertimeHours, UndertimeHours, LateHours) VALUES ('"+txtEmpID.Text+"','"+cmbMonth.Text+"','"+cmbYear.Text+"','"+txtPresent.Text+"','"+txtAbsent.Text+"','"+txtReg.Text+"','"+txtSp.Text+"','"+txtOT.Text+"','"+txtUT.Text+"','"+txtLate.Text+"')");
                ClearData();
                MessageBox.Show("Attendance Record Save Successfully", "Message", MessageBoxButtons.OK);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to edit?", "Edit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("UPDATE Attendance SET PresentDays ='"+txtPresent.Text+"', Absents ='"+txtAbsent.Text+"', RegularHoliday ='"+txtReg.Text+"', SpecialHoliday ='"+txtSp.Text+"', OvertimeHours ='"+txtOT.Text+"', UndertimeHours ='"+txtUT.Text+"', LateHours ='"+txtLate.Text+ "' WHERE ID = '"+txtEmpID.Text+"' AND Month = '"+cmbMonth.Text+"' AND Year = '"+cmbYear.Text+"'");
                MessageBox.Show("Successfully Edited", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearData();
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con.dataSend("DELETE FROM Attendance WHERE ID = '"+txtEmpID.Text+"' AND Month = '"+cmbMonth.Text+"' AND Year = '"+cmbYear.Text+"'");
                MessageBox.Show("Successfully Removed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
