using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessengerService
{
    public partial class MessengerService : ServiceBase
    {
        private const string LogsFilePath = "D:\\Report.txt";
        private static readonly TimeSpan UpdatePeriod = TimeSpan.FromSeconds(1.0f);
        private Timer _updateTimer;

        private StreamWriter _logsWriter;
        
        public MessengerService()
        {
            InitializeComponent();

            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }
        
        private void Log(string message)
        {
            using (_logsWriter = new StreamWriter(LogsFilePath, true))
            {
                _logsWriter.WriteLine(message);
                _logsWriter.Flush();
            }
        }

        private void LogUpdateEvent(object p) => Log("Updated event");
        
        protected override void OnStart(string[] args)
        {
            Log("Service started");
            
            _updateTimer = new Timer(LogUpdateEvent, null,UpdatePeriod, UpdatePeriod);
        }

        protected override void OnPause()
        {
            _updateTimer.Dispose();
            Log("Service paused");
        }

        protected override void OnContinue()
        {
            Log("Service continued");
            _updateTimer = new Timer(LogUpdateEvent, null,UpdatePeriod, UpdatePeriod);
        }

        protected override void OnStop()
        {
            _updateTimer.Dispose();
            Log("Service stopped");
        }
    }
}
