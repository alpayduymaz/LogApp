using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
        }

        public void onDebug()
        {
            OnStart(null);
        }
        private Timer timer;

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = 60000; // 1 dakika için
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            CreateLogFile(); // Dosyayı oluştur
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string programDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string veriketAppFolder = Path.Combine(programDataFolder, "VeriketApp");
            string filePath = Path.Combine(veriketAppFolder, "VeriketAppTest.txt");

            string logLine = $"{DateTime.Now} {Environment.MachineName} {Environment.UserName}";

            File.AppendAllText(filePath, logLine + Environment.NewLine);
        }

        private void CreateLogFile()
        {
            string programDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string veriketAppFolder = Path.Combine(programDataFolder, "VeriketApp");
            string filePath = Path.Combine(veriketAppFolder, "VeriketAppTest.txt");

            // Dosya zaten varsa oluşturmaya gerek yok
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(veriketAppFolder);
                File.Create(filePath).Close();
            }
        }

        protected override void OnStop()
        {
            // Durduğunda herhangi bir işlem yapılmasına gerek yok
        }
    }
}
