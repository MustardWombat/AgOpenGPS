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
        private string logFilePath;
        private DateTime lastSaveTime;
        private readonly TimeSpan autoSaveInterval = TimeSpan.FromSeconds(5);

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
        private readonly TimeSpan logInterval = TimeSpan.FromSeconds(1); // Log every second
        private bool isRecording = true; // Start recording by default

        public bool IsRecording => isRecording;
        public string LogFilePath => logFilePath;

        public bool ShouldLog()
        {
            return isRecording && DateTime.Now - lastLogTime > logInterval;
        }

        public CNavigationLogger()
        {
            navigationHistory = new List<NavigationData>();
            
            // Save log file in the application directory instead of Documents
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            logFilePath = Path.Combine(appDirectory, "NavigationLog.txt");
            
            // Ensure directory exists
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                
                // Create initial file with header
                CreateInitialLogFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating navigation log directory: {ex.Message}");
            }
            
            lastSaveTime = DateTime.Now;
        }

        private void CreateInitialLogFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine("AgOpenGPS Navigation Log");
                    writer.WriteLine("========================");
                    writer.WriteLine($"Log Started: {DateTime.Now}");
                    writer.WriteLine($"Log File Path: {logFilePath}");
                    writer.WriteLine();
                    writer.WriteLine("Timestamp\t\tXTE\tLatitude\tLongitude");
                    writer.WriteLine("------------------------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating initial navigation log file: {ex.Message}");
            }
        }

        public void LogNavigationData(double xte, double lat, double lon)
        {
            // Keep the 1-second timing but log whenever XTE is available
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
            
            // Auto-save every 5 seconds
            if (DateTime.Now - lastSaveTime > autoSaveInterval)
            {
                SaveToFile();
                lastSaveTime = DateTime.Now;
            }
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
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine("AgOpenGPS Navigation Log");
                    writer.WriteLine("========================");
                    writer.WriteLine($"Generated: {DateTime.Now}");
                    writer.WriteLine($"Log File Path: {logFilePath}");
                    writer.WriteLine($"Total Records: {navigationHistory.Count}");
                    writer.WriteLine();
                    writer.WriteLine("Timestamp\t\tXTE\tLatitude\tLongitude");
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving navigation log: {ex.Message}");
            }
        }
    }
}
