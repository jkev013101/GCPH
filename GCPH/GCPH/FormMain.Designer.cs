namespace GCPH
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uSERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeSalaryRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uSERToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.payrollToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1272, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uSERToolStripMenuItem
            // 
            this.uSERToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.uSERToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userRegisterToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.uSERToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uSERToolStripMenuItem.Name = "uSERToolStripMenuItem";
            this.uSERToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.uSERToolStripMenuItem.Text = "User";
            // 
            // userRegisterToolStripMenuItem
            // 
            this.userRegisterToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.userRegisterToolStripMenuItem.Name = "userRegisterToolStripMenuItem";
            this.userRegisterToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.userRegisterToolStripMenuItem.Text = "User Register";
            this.userRegisterToolStripMenuItem.Click += new System.EventHandler(this.userRegisterToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.employeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeRegisterToolStripMenuItem,
            this.employeeSalaryRateToolStripMenuItem,
            this.deductionsToolStripMenuItem,
            this.employeeAttendanceToolStripMenuItem});
            this.employeeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // employeeRegisterToolStripMenuItem
            // 
            this.employeeRegisterToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.employeeRegisterToolStripMenuItem.Name = "employeeRegisterToolStripMenuItem";
            this.employeeRegisterToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.employeeRegisterToolStripMenuItem.Text = "Employee Data";
            this.employeeRegisterToolStripMenuItem.Click += new System.EventHandler(this.employeeRegisterToolStripMenuItem_Click);
            // 
            // employeeSalaryRateToolStripMenuItem
            // 
            this.employeeSalaryRateToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.employeeSalaryRateToolStripMenuItem.Name = "employeeSalaryRateToolStripMenuItem";
            this.employeeSalaryRateToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.employeeSalaryRateToolStripMenuItem.Text = "Employee Salary Rate";
            this.employeeSalaryRateToolStripMenuItem.Click += new System.EventHandler(this.employeeSalaryRateToolStripMenuItem_Click);
            // 
            // deductionsToolStripMenuItem
            // 
            this.deductionsToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.deductionsToolStripMenuItem.Name = "deductionsToolStripMenuItem";
            this.deductionsToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.deductionsToolStripMenuItem.Text = "Employee Deductions";
            this.deductionsToolStripMenuItem.Click += new System.EventHandler(this.deductionsToolStripMenuItem_Click);
            // 
            // employeeAttendanceToolStripMenuItem
            // 
            this.employeeAttendanceToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.employeeAttendanceToolStripMenuItem.Name = "employeeAttendanceToolStripMenuItem";
            this.employeeAttendanceToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.employeeAttendanceToolStripMenuItem.Text = "Employee Attendance";
            this.employeeAttendanceToolStripMenuItem.Click += new System.EventHandler(this.employeeAttendanceToolStripMenuItem_Click);
            // 
            // payrollToolStripMenuItem
            // 
            this.payrollToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.payrollToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payrollToolStripMenuItem.Name = "payrollToolStripMenuItem";
            this.payrollToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.payrollToolStripMenuItem.Text = "Payroll";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1272, 705);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Golden Crown Petals and Herb Payroll Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uSERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeSalaryRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deductionsToolStripMenuItem;
    }
}