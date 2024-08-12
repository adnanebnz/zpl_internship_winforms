using System;
using System.IO;
using System.Reflection;

namespace XmlToZpl.Utils
{
    public class LoggerUtil
    {
        public static void LogError(Exception ex, string className, string methodName)
        {
            string logFilePath = "error_log.txt";
            try
            {
                string message = $"{DateTime.Now}: Error in {className}.{methodName} - {ex.Message}\n";
                File.AppendAllText(logFilePath, message);
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Failed to write to log file: {logEx.Message}");
            }
        }
    }
}
