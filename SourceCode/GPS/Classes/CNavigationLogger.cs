using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AgOpenGPS
{
    public class CNavigationLogger
    {
        public struct NavigationData
        {
            public DateTime Timestamp;
            public double CrossTrackError;
            public double Latitude;
            public double Longitude;
        }

        private List<NavigationData> navigationHistory;
        private string logDirectory;
        private DateTime lastSaveTime;

        // Add static instance for global access
        private static CNavigationLogger _instance;
        public static CNavigationLogger Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CNavigationLogger();
                return _instance;
            }
        }

        // Add method to check if logging should occur (to avoid excessive logging)
        private DateTime lastLogTime = DateTime.MinValue;
        private TimeSpan logInterval = TimeSpan.FromSeconds(1); // Log every second
        public double RecordingIntervalSeconds
        {
            get => logInterval.TotalSeconds;
            set => logInterval = TimeSpan.FromSeconds(value);
        }
        private bool isRecording = true; // Start recording by default

        public bool IsRecording => isRecording;
        public string LogDirectory => logDirectory;

        public bool ShouldLog()
        {
            return isRecording && DateTime.Now - lastLogTime > logInterval;
        }

        public CNavigationLogger()
        {
            navigationHistory = new List<NavigationData>();
            
            // Save log files in the application directory
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            logDirectory = Path.Combine(appDirectory, "NavigationLogs");
            
            // Ensure directory exists
            try
            {
                Directory.CreateDirectory(logDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating navigation log directory: {ex.Message}");
            }
            
            lastSaveTime = DateTime.Now;
        }

        public void LogNavigationData(double xte, double lat, double lon)
        {
            if (!ShouldLog()) return;

            lastLogTime = DateTime.Now;

            var data = new NavigationData
            {
                Timestamp = DateTime.Now,
                CrossTrackError = xte,
                Latitude = lat,
                Longitude = lon
            };

            navigationHistory.Add(data);
        }

        public List<NavigationData> GetNavigationHistory() => navigationHistory;

        public void StartRecording()
        {
            isRecording = true;
        }

        public void StopRecording()
        {
            isRecording = false;
        }

        public void ClearHistory()
        {
            navigationHistory.Clear();
        }

        public void SaveToFile()
        {
            // Create timestamped filename
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string filename = $"NavigationLog_{timestamp}.txt";
            string filepath = Path.Combine(logDirectory, filename);

            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, false))
                {
                    writer.WriteLine("AgOpenGPS Navigation Log");
                    writer.WriteLine("========================");
                    writer.WriteLine($"Generated: {DateTime.Now}");
                    writer.WriteLine($"Recording Interval: {logInterval.TotalSeconds:F1} seconds");
                    writer.WriteLine($"Total Records: {navigationHistory.Count}");
                    writer.WriteLine();
                    writer.WriteLine("Timestamp\t\t\tXTE (m)\tLatitude\tLongitude");
                    writer.WriteLine("------------------------------------------------------------------------");

                    foreach (var data in navigationHistory)
                    {
                        writer.WriteLine(
                            $"{data.Timestamp:yyyy-MM-dd HH:mm:ss.fff}\t" +
                            $"{data.CrossTrackError:F3}\t" +
                            $"{data.Latitude:F8}\t" +
                            $"{data.Longitude:F8}");
                    }
                }
                
                Console.WriteLine($"Navigation log saved: {filepath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving navigation log: {ex.Message}");
                throw;
            }
        }
    }
}
