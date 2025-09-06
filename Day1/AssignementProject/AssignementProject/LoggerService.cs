using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AssignementProject
{
    public static class LoggerService
    {
        private static readonly string logFile = "application.log";

        public static void LogInfo(string message) => Log("INFO", message);
        public static void LogError(string message) => Log("ERROR", message);

        private static void Log(string level, string message)
        {
            string logEntry = $"{DateTime.Now:u} [{level}] {message}";
            Console.WriteLine(logEntry);
            File.AppendAllText(logFile, logEntry + Environment.NewLine);
    
        }
    }
}
