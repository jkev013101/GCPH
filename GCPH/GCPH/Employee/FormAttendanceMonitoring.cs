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
    public partial class FormAttendanceMonitoring : Form
    {
        public FormAttendanceMonitoring()
        {
            InitializeComponent();
        }

        private void FormAttendanceMonitoring_Load(object sender, EventArgs e)
        {
            cmbYear.Items.Add((DateTime.Now.Year) - 1);
            cmbYear.Items.Add((DateTime.Now.Year));
            cmbYear.Items.Add((DateTime.Now.Year) + 1);
            cmbYear.SelectedItem = cmbYear.Items[1];
        }
    }
}
