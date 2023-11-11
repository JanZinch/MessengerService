using System;
using System.IO;
using MessengerService.Core.Models;

namespace MessengerService.Utilities
{
    public static class LogUtility
    {
        private static string AppDataPath => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private const string AppFolderName = "MessengerService";
        private const string LogsFileName = "MessengerLogs.txt";
        
        private static DirectoryInfo _appDirectoryInfo;
        private static StreamWriter _writer;
        
        static LogUtility()
        {
            CheckApplicationFolder();
        }
    
        private static void CheckApplicationFolder()
        {
            string path = Path.Combine(AppDataPath, AppFolderName);
            _appDirectoryInfo = new DirectoryInfo(path);
        
            if (!_appDirectoryInfo.Exists)
            {
                _appDirectoryInfo.Create();
            }
        }

        public static void WriteMessage(Message message)
        {
            WriteLine(string.Format("\n{0}\n{1}\n{2}\n", message.SenderNickname, message.Text, message.PostDateTime));
        }

        public static void WriteLine(string message)
        {
            string fullLogsFileName = Path.Combine(_appDirectoryInfo.FullName, LogsFileName);
            using (_writer = new StreamWriter(fullLogsFileName, true))
            {
                _writer.WriteLine(message);
                _writer.Flush();
            }
        }
        
    }
}