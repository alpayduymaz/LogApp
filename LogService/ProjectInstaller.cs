using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LogService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public ProjectInstaller()
        {
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            serviceInstaller.ServiceName = "MyLogService"; // Hizmetin adı
            serviceInstaller.Description = "My Log Service"; // Hizmetin açıklaması

            processInstaller.Account = ServiceAccount.LocalSystem;

            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
