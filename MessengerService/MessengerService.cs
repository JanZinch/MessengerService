using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MessengerService
{
    public partial class MessengerService : ServiceBase
    {
        public MessengerService()
        {
            InitializeComponent();

            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            Console.WriteLine("Service initialized");
        }

        protected override void OnStop()
        {
            Console.WriteLine("Service stopped");
        }
    }
}
