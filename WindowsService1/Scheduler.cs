using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService1
{
    public partial class Scheduler : ServiceBase
    {
        private Timer timer1 = null;

        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 30000; //every 30 seconds
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.Enabled = true;
            Libary.WriteErrorLog("Test windows service started");
        }
        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            Libary.WriteErrorLog("Timer ticked and some job has been done succesfully");
        }
        protected override void OnStop()
        {
            timer1.Enabled = false;
            Libary.WriteErrorLog("Test windows service stopped");
        }
    }
}
