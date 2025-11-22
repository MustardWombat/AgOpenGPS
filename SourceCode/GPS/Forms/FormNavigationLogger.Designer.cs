namespace AgOpenGPS
{
    partial class FormNavigationLogger
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
            this.lblRecordCount = new System.Windows.Forms.Label();
            this.lblCurrentXTE = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnToggleRecording = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpRecordingMode = new System.Windows.Forms.GroupBox();
            this.rbByTime = new System.Windows.Forms.RadioButton();
            this.rbByDistance = new System.Windows.Forms.RadioButton();
            this.lblRecordingInterval = new System.Windows.Forms.Label();
            this.nudRecordingInterval = new System.Windows.Forms.NumericUpDown();
            this.lblRecordsPerSecond = new System.Windows.Forms.Label();
            this.lblDistanceInterval = new System.Windows.Forms.Label();
            this.nudDistanceInterval = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.grpRecordingMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecordingInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRecordCount
            // 
            this.lblRecordCount.AutoSize = true;
            this.lblRecordCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordCount.ForeColor = System.Drawing.Color.Black;
            this.lblRecordCount.Location = new System.Drawing.Point(20, 20);
            this.lblRecordCount.Name = "lblRecordCount";
            this.lblRecordCount.Size = new System.Drawing.Size(100, 19);
            this.lblRecordCount.TabIndex = 0;
            this.lblRecordCount.Text = "Records: 0";
            // 
            // lblCurrentXTE
            // 
            this.lblCurrentXTE.AutoSize = true;
            this.lblCurrentXTE.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblCurrentXTE.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentXTE.Location = new System.Drawing.Point(20, 50);
            this.lblCurrentXTE.Name = "lblCurrentXTE";
            this.lblCurrentXTE.Size = new System.Drawing.Size(130, 19);
            this.lblCurrentXTE.TabIndex = 1;
            this.lblCurrentXTE.Text = "Current XTE: --";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(20, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(167, 19);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status: Recording";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(20, 120);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(730, 280);
            this.dgvHistory.TabIndex = 3;
            // 
            // btnToggleRecording
            // 
            this.btnToggleRecording.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleRecording.FlatAppearance.BorderSize = 0;
            this.btnToggleRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleRecording.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnToggleRecording.Image = global::AgOpenGPS.Properties.Resources.Stop;
            this.btnToggleRecording.Location = new System.Drawing.Point(20, 420);
            this.btnToggleRecording.Name = "btnToggleRecording";
            this.btnToggleRecording.Size = new System.Drawing.Size(150, 80);
            this.btnToggleRecording.TabIndex = 4;
            this.btnToggleRecording.Text = "Stop";
            this.btnToggleRecording.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnToggleRecording.UseVisualStyleBackColor = false;
            this.btnToggleRecording.Click += new System.EventHandler(this.btnToggleRecording_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnSave.Image = global::AgOpenGPS.Properties.Resources.FileSave;
            this.btnSave.Location = new System.Drawing.Point(200, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 80);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnClear.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnClear.Location = new System.Drawing.Point(380, 420);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 80);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnClose.Image = global::AgOpenGPS.Properties.Resources.back_button;
            this.btnClose.Location = new System.Drawing.Point(600, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 80);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // grpRecordingMode
            // 
            this.grpRecordingMode.Controls.Add(this.rbByTime);
            this.grpRecordingMode.Controls.Add(this.rbByDistance);
            this.grpRecordingMode.Controls.Add(this.lblRecordingInterval);
            this.grpRecordingMode.Controls.Add(this.nudRecordingInterval);
            this.grpRecordingMode.Controls.Add(this.lblRecordsPerSecond);
            this.grpRecordingMode.Controls.Add(this.lblDistanceInterval);
            this.grpRecordingMode.Controls.Add(this.nudDistanceInterval);
            this.grpRecordingMode.Location = new System.Drawing.Point(400, 10);
            this.grpRecordingMode.Name = "grpRecordingMode";
            this.grpRecordingMode.Size = new System.Drawing.Size(350, 100);
            this.grpRecordingMode.TabIndex = 8;
            this.grpRecordingMode.TabStop = false;
            this.grpRecordingMode.Text = "Recording Mode";
            // 
            // rbByTime
            // 
            this.rbByTime.AutoSize = true;
            this.rbByTime.Location = new System.Drawing.Point(10, 20);
            this.rbByTime.Name = "rbByTime";
            this.rbByTime.Size = new System.Drawing.Size(70, 17);
            this.rbByTime.TabIndex = 0;
            this.rbByTime.Text = "By Time";
            this.rbByTime.UseVisualStyleBackColor = true;
            this.rbByTime.CheckedChanged += new System.EventHandler(this.rbByTime_CheckedChanged);
            // 
            // rbByDistance
            // 
            this.rbByDistance.AutoSize = true;
            this.rbByDistance.Location = new System.Drawing.Point(10, 65);
            this.rbByDistance.Name = "rbByDistance";
            this.rbByDistance.Size = new System.Drawing.Size(90, 17);
            this.rbByDistance.TabIndex = 1;
            this.rbByDistance.Text = "By Distance";
            this.rbByDistance.UseVisualStyleBackColor = true;
            this.rbByDistance.CheckedChanged += new System.EventHandler(this.rbByDistance_CheckedChanged);
            // 
            // lblRecordingInterval
            // 
            this.lblRecordingInterval.AutoSize = true;
            this.lblRecordingInterval.Location = new System.Drawing.Point(30, 43);
            this.lblRecordingInterval.Name = "lblRecordingInterval";
            this.lblRecordingInterval.Size = new System.Drawing.Size(51, 13);
            this.lblRecordingInterval.Text = "Interval (s):";
            // 
            // nudRecordingInterval
            // 
            this.nudRecordingInterval.DecimalPlaces = 1;
            this.nudRecordingInterval.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudRecordingInterval.Location = new System.Drawing.Point(90, 41);
            this.nudRecordingInterval.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudRecordingInterval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudRecordingInterval.Name = "nudRecordingInterval";
            this.nudRecordingInterval.Size = new System.Drawing.Size(70, 20);
            this.nudRecordingInterval.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            this.nudRecordingInterval.ValueChanged += new System.EventHandler(this.nudRecordingInterval_ValueChanged);
            // 
            // lblRecordsPerSecond
            // 
            this.lblRecordsPerSecond.AutoSize = true;
            this.lblRecordsPerSecond.Location = new System.Drawing.Point(166, 43);
            this.lblRecordsPerSecond.Name = "lblRecordsPerSecond";
            this.lblRecordsPerSecond.Size = new System.Drawing.Size(100, 13);
            this.lblRecordsPerSecond.Text = "(1.0 records/sec)";
            // 
            // lblDistanceInterval
            // 
            this.lblDistanceInterval.AutoSize = true;
            this.lblDistanceInterval.Location = new System.Drawing.Point(30, 88);
            this.lblDistanceInterval.Name = "lblDistanceInterval";
            this.lblDistanceInterval.Size = new System.Drawing.Size(54, 13);
            this.lblDistanceInterval.Text = "Interval (m):";
            // 
            // nudDistanceInterval
            // 
            this.nudDistanceInterval.DecimalPlaces = 1;
            this.nudDistanceInterval.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.nudDistanceInterval.Location = new System.Drawing.Point(90, 86);
            this.nudDistanceInterval.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.nudDistanceInterval.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            this.nudDistanceInterval.Name = "nudDistanceInterval";
            this.nudDistanceInterval.Size = new System.Drawing.Size(70, 20);
            this.nudDistanceInterval.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            this.nudDistanceInterval.ValueChanged += new System.EventHandler(this.nudDistanceInterval_ValueChanged);
            // 
            // FormNavigationLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.grpRecordingMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnToggleRecording);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCurrentXTE);
            this.Controls.Add(this.lblRecordCount);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNavigationLogger";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Navigation Logger";
            this.Load += new System.EventHandler(this.FormNavigationLogger_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormNavigationLogger_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.grpRecordingMode.ResumeLayout(false);
            this.grpRecordingMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRecordingInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblRecordCount;
        private System.Windows.Forms.Label lblCurrentXTE;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnToggleRecording;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpRecordingMode;
        private System.Windows.Forms.RadioButton rbByTime;
        private System.Windows.Forms.RadioButton rbByDistance;
        private System.Windows.Forms.Label lblRecordingInterval;
        private System.Windows.Forms.NumericUpDown nudRecordingInterval;
        private System.Windows.Forms.Label lblRecordsPerSecond;
        private System.Windows.Forms.Label lblDistanceInterval;
        private System.Windows.Forms.NumericUpDown nudDistanceInterval;
    }
}
