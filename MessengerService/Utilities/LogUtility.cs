﻿using System;
using System.IO;

namespace MessengerService.Utilities
{
    public static class LogUtility
    {
        //C:\ProgramData\MessengerService
        private static string AppDataPath => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private const string AppFolderName = "MessengerService";
        private const string LogsFileName = "Logs.txt";
        
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
        
        public static void WriteLine(string message)
        {
            try {

                string fullLogsFileName = Path.Combine(_appDirectoryInfo.FullName, LogsFileName);
                using (_writer = new StreamWriter(fullLogsFileName, true))
                {
                    _writer.WriteLine(message);
                    _writer.Flush();
                }
            }
            catch (Exception ex)
            {
                StreamWriter file = new StreamWriter("D:\\MessengerServiceCrashReport.txt");
                file.WriteLine(ex.Message + "\n" + ex.StackTrace);
                file.Close();
            }
    
        }
        
    }
}