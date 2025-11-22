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
            logger.SaveToFile();
            MessageBox.Show($"Navigation log saved successfully!\n\nLocation:\n{logger.LogFilePath}", 
                "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
