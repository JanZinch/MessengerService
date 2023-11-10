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
using MessengerService.Service;
using MessengerService.Utilities;

namespace MessengerService
{
    public partial class MessengerService : ServiceBase
    {
        private ServiceClient _serviceClient;

        public MessengerService()
        {
            InitializeComponent();

            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }
        
        protected override void OnStart(string[] args)
        {
            _serviceClient = new ServiceClient();
            LogUtility.WriteLine("Service started");
        }

        protected override void OnPause()
        {
            _serviceClient.Stop();
            LogUtility.WriteLine("Service paused");
        }

        protected override void OnContinue()
        {
            _serviceClient.Start();
            LogUtility.WriteLine("Service continued");
        }

        protected override void OnStop()
        {
            _serviceClient.Dispose();
            LogUtility.WriteLine("Service stopped");
        }
    }
}
