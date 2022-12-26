namespace GCPH.Attendance
{
    partial class FormBiometricsData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBiometricsData));
            this.btnOpen = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFirstIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFirstTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSecondTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSecondTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgNumber,
            this.dgID,
            this.dgName,
            this.dgDept,
            this.dgDate,
            this.dgFirstIn,
            this.dgFirstTimeOut,
            this.dgSecondTimeIn,
            this.dgSecondTimeOut});
            this.dataGridView1.Location = new System.Drawing.Point(13, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(944, 632);
            this.dataGridView1.TabIndex = 1;
            // 
            // dgNumber
            // 
            this.dgNumber.HeaderText = "No.";
            this.dgNumber.MinimumWidth = 6;
            this.dgNumber.Name = "dgNumber";
            this.dgNumber.ReadOnly = true;
            this.dgNumber.Width = 125;
            // 
            // dgID
            // 
            this.dgID.HeaderText = "ID";
            this.dgID.MinimumWidth = 6;
            this.dgID.Name = "dgID";
            this.dgID.ReadOnly = true;
            this.dgID.Width = 125;
            // 
            // dgName
            // 
            this.dgName.HeaderText = "Name";
            this.dgName.MinimumWidth = 6;
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            this.dgName.Width = 125;
            // 
            // dgDept
            // 
            this.dgDept.HeaderText = "Department";
            this.dgDept.MinimumWidth = 6;
            this.dgDept.Name = "dgDept";
            this.dgDept.ReadOnly = true;
            this.dgDept.Width = 125;
            // 
            // dgDate
            // 
            this.dgDate.HeaderText = "Date";
            this.dgDate.MinimumWidth = 6;
            this.dgDate.Name = "dgDate";
            this.dgDate.ReadOnly = true;
            this.dgDate.Width = 125;
            // 
            // dgFirstIn
            // 
            this.dgFirstIn.HeaderText = "First In";
            this.dgFirstIn.MinimumWidth = 6;
            this.dgFirstIn.Name = "dgFirstIn";
            this.dgFirstIn.ReadOnly = true;
            this.dgFirstIn.Width = 125;
            // 
            // dgFirstTimeOut
            // 
            this.dgFirstTimeOut.HeaderText = "First Out";
            this.dgFirstTimeOut.MinimumWidth = 6;
            this.dgFirstTimeOut.Name = "dgFirstTimeOut";
            this.dgFirstTimeOut.ReadOnly = true;
            this.dgFirstTimeOut.Width = 125;
            // 
            // dgSecondTimeIn
            // 
            this.dgSecondTimeIn.HeaderText = "Second In";
            this.dgSecondTimeIn.MinimumWidth = 6;
            this.dgSecondTimeIn.Name = "dgSecondTimeIn";
            this.dgSecondTimeIn.ReadOnly = true;
            this.dgSecondTimeIn.Width = 125;
            // 
            // dgSecondTimeOut
            // 
            this.dgSecondTimeOut.HeaderText = "Second Out";
            this.dgSecondTimeOut.MinimumWidth = 6;
            this.dgSecondTimeOut.Name = "dgSecondTimeOut";
            this.dgSecondTimeOut.ReadOnly = true;
            this.dgSecondTimeOut.Width = 125;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(103, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(872, 687);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormBiometricsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 722);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBiometricsData";
            this.Text = "Biometrics Data";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFirstIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFirstTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSecondTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSecondTimeOut;
    }
}