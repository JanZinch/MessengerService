using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace MessengerService
{
    [RunInstaller(true)]
    public partial class MessengerServiceInstaller : System.Configuration.Install.Installer
    {
        ServiceInstaller _serviceInstaller;
        ServiceProcessInstaller _processInstaller;

        public MessengerServiceInstaller()
        {
            InitializeComponent();
            _serviceInstaller = new ServiceInstaller();
            _processInstaller = new ServiceProcessInstaller();

            _serviceInstaller.StartType = ServiceStartMode.Manual;
            _serviceInstaller.ServiceName = "MessengerService";
            _processInstaller.Account = ServiceAccount.LocalSystem;

            Installers.Add(_processInstaller);
            Installers.Add(_serviceInstaller);


        }
    }
}
