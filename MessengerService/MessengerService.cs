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
using MessengerService.Utilities;

namespace MessengerService
{
    public partial class MessengerService : ServiceBase
    {
        private static readonly TimeSpan UpdatePeriod = TimeSpan.FromSeconds(1.0f);
        private Timer _updateTimer;

        public MessengerService()
        {
            InitializeComponent();

            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        private void LogUpdateEvent(object p) => LogUtility.WriteLine("Updated event");
        
        protected override void OnStart(string[] args)
        {
            LogUtility.WriteLine("Service started");
            
            _updateTimer = new Timer(LogUpdateEvent, null,UpdatePeriod, UpdatePeriod);
        }

        protected override void OnPause()
        {
            _updateTimer.Dispose();
            LogUtility.WriteLine("Service paused");
        }

        protected override void OnContinue()
        {
            LogUtility.WriteLine("Service continued");
            _updateTimer = new Timer(LogUpdateEvent, null,UpdatePeriod, UpdatePeriod);
        }

        protected override void OnStop()
        {
            _updateTimer.Dispose();
            LogUtility.WriteLine("Service stopped");
        }
    }
}
