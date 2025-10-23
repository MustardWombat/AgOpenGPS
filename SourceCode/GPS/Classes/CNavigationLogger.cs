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
            public double LateralOffset;
            public double Heading;
            public double Speed;
            public double Latitude;
            public double Longitude;
        }

        private List<NavigationData> navigationHistory;
        private string logFilePath;
        private DateTime lastSaveTime;
        private readonly TimeSpan autoSaveInterval = TimeSpan.FromSeconds(5);

        public CNavigationLogger()
        {
            navigationHistory = new List<NavigationData>();
            
            // Save log file in the application directory instead of Documents
            string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            logFilePath = Path.Combine(appDirectory, "NavigationLog.txt");
            
            lastSaveTime = DateTime.Now;
        }

        public void LogNavigationData(double xte, double lateralOffset, double heading, double speed, double lat, double lon)
        {
            var data = new NavigationData
            {
                Timestamp = DateTime.Now,
                CrossTrackError = xte,
                LateralOffset = lateralOffset,
                Heading = heading,
                Speed = speed,
                Latitude = lat,
                Longitude = lon
            };

            navigationHistory.Add(data);
            
            // Auto-save every 10 seconds
            if (DateTime.Now - lastSaveTime > autoSaveInterval)
            {
                SaveToFile();
                lastSaveTime = DateTime.Now;
            }
        }

        public List<NavigationData> GetNavigationHistory() => navigationHistory;

        public void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, false))
                {
                    writer.WriteLine("AgOpenGPS Navigation Log");
                    writer.WriteLine("========================");
                    writer.WriteLine($"Generated: {DateTime.Now}");
                    writer.WriteLine();
                    writer.WriteLine("Timestamp\t\tXTE\tLateral Offset\tHeading\tSpeed\tLatitude\tLongitude");
                    writer.WriteLine("------------------------------------------------------------------------");

                    foreach (var data in navigationHistory)
                    {
                        writer.WriteLine($"{data.Timestamp:yyyy-MM-dd HH:mm:ss.fff}\t{data.CrossTrackError:F3}\t{data.LateralOffset:F3}\t{data.Heading:F1}\t{data.Speed:F2}\t{data.Latitude:F8}\t{data.Longitude:F8}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle file write errors silently for now
                Console.WriteLine($"Error saving navigation log: {ex.Message}");
            }
        }
    }
}
