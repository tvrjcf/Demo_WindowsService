using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DEMO_WindowsService
{
    public partial class Demo_Service : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public Demo_Service()
        {
            InitializeComponent();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(ElapsedEventHandler);
            timer.Interval = 5000;
        }

        protected override void OnStart(string[] args)
        {
            timer.Enabled = true; ;
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Enabled = false; ;
            timer.Stop();
        }

        void ElapsedEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Testlog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
        }
    }
}
