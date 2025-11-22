using System;
using System.Windows.Forms;
using System.Drawing;

namespace AgOpenGPS
{
    public partial class FormNavigationLogger : Form
    {
        private readonly CNavigationLogger logger;
        private Timer updateTimer;

        public FormNavigationLogger()
        {
            InitializeComponent();
            logger = CNavigationLogger.Instance;
        }

        private void FormNavigationLogger_Load(object sender, EventArgs e)
        {
            // Update display every second
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
            
            // Initialize mode radio buttons
            rbByTime.Checked = logger.Mode == CNavigationLogger.RecordingMode.ByTime;
            rbByDistance.Checked = logger.Mode == CNavigationLogger.RecordingMode.ByDistance;

            // Initialize interval controls with current values
            nudRecordingInterval.Value = (decimal)logger.RecordingIntervalSeconds;
            nudDistanceInterval.Value = (decimal)logger.RecordingIntervalDistance;
            
            // Update the records per second label initially
            UpdateIntervalLabels();
            UpdateModeControls();
            
            // Initial update
            UpdateDisplay();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            var history = logger.GetNavigationHistory();
            
            // Update record count
            lblRecordCount.Text = $"Records: {history.Count}";
            
            // Update current XTE
            if (history.Count > 0)
            {
                var latest = history[history.Count - 1];
                lblCurrentXTE.Text = $"Current XTE: {latest.CrossTrackError:F3} m";
            }
            else
            {
                lblCurrentXTE.Text = "Current XTE: --";
            }
            
            // Update data grid (show last 50 records)
            if (history.Count > 0)
            {
                dgvHistory.DataSource = null;
                int startIndex = Math.Max(0, history.Count - 50);
                dgvHistory.DataSource = history.GetRange(startIndex, history.Count - startIndex);
            }
        }

        private void UpdateIntervalLabels()
        {
            lblRecordsPerSecond.Text = $"({(1.0 / (double)nudRecordingInterval.Value):F1} records/sec)";
        }

        private void UpdateModeControls()
        {
            bool isByTime = rbByTime.Checked;
            lblRecordingInterval.Enabled = isByTime;
            nudRecordingInterval.Enabled = isByTime;
            lblRecordsPerSecond.Enabled = isByTime;

            lblDistanceInterval.Enabled = !isByTime;
            nudDistanceInterval.Enabled = !isByTime;
        }

        private void rbByTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByTime.Checked)
            {
                logger.Mode = CNavigationLogger.RecordingMode.ByTime;
                UpdateModeControls();
            }
        }

        private void rbByDistance_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByDistance.Checked)
            {
                logger.Mode = CNavigationLogger.RecordingMode.ByDistance;
                UpdateModeControls();
            }
        }

        private void nudRecordingInterval_ValueChanged(object sender, EventArgs e)
        {
            logger.RecordingIntervalSeconds = (double)nudRecordingInterval.Value;
            UpdateIntervalLabels();
        }

        private void nudDistanceInterval_ValueChanged(object sender, EventArgs e)
        {
            logger.RecordingIntervalDistance = (double)nudDistanceInterval.Value;
        }

        private void nudSaveInterval_ValueChanged(object sender, EventArgs e)
        {
            // No longer used - keeping for compatibility with designer
        }

        private void btnToggleRecording_Click(object sender, EventArgs e)
        {
            if (logger.IsRecording)
            {
                logger.StopRecording();
                btnToggleRecording.Text = "Start";
                lblStatus.Text = "Status: Stopped";
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                logger.StartRecording();
                btnToggleRecording.Text = "Stop";
                lblStatus.Text = "Status: Recording";
                lblStatus.ForeColor = Color.Green;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                logger.SaveToFile();
                MessageBox.Show($"Navigation log saved successfully!\n\nLocation:\n{logger.LogDirectory}", 
                    "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving log: {ex.Message}", 
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the navigation history?", 
                "Clear History", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                logger.ClearHistory();
                UpdateDisplay();
            }
        }

        private void FormNavigationLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer?.Stop();
            updateTimer?.Dispose();
        }
    }
}
