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

        public enum RecordingMode
        {
            ByTime,
            ByDistance
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

        private RecordingMode recordingMode = RecordingMode.ByTime;
        public RecordingMode Mode
        {
            get => recordingMode;
            set => recordingMode = value;
        }

        private double distanceInterval = 1.0; // meters
        public double RecordingIntervalDistance
        {
            get => distanceInterval;
            set => distanceInterval = value;
        }

        private double lastLogLat = double.NaN;
        private double lastLogLon = double.NaN;

        private bool isRecording = true; // Start recording by default

        public bool IsRecording => isRecording;
        public string LogDirectory => logDirectory;

        public bool ShouldLog()
        {
            return isRecording && DateTime.Now - lastLogTime > logInterval;
        }

        private bool ShouldLogByDistance(double lat, double lon)
        {
            if (!isRecording) return false;
            
            if (double.IsNaN(lastLogLat) || double.IsNaN(lastLogLon))
                return true;

            double distance = CalculateDistance(lastLogLat, lastLogLon, lat, lon);
            return distance >= distanceInterval;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Haversine formula to calculate distance in meters
            const double R = 6371000; // Earth radius in meters
            double dLat = ToRadians(lat2 - lat1);
            double dLon = ToRadians(lon2 - lon1);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                      Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                      Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
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
            bool shouldLog = recordingMode == RecordingMode.ByTime 
                ? ShouldLog() 
                : ShouldLogByDistance(lat, lon);

            if (!shouldLog) return;

            lastLogTime = DateTime.Now;
            lastLogLat = lat;
            lastLogLon = lon;

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
                    writer.WriteLine($"Recording Mode: {recordingMode}");
                    if (recordingMode == RecordingMode.ByTime)
                        writer.WriteLine($"Recording Interval: {logInterval.TotalSeconds:F1} seconds");
                    else
                        writer.WriteLine($"Recording Interval: {distanceInterval:F1} meters");
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
