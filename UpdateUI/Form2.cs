using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateUI
{
    public partial class Form2 : Form
    {
        BackgroundWorker workerThread = null;

        bool _keepRunning = false;

        public Form2()
        {
            InitializeComponent();

            InstantiateWorkerThread();
        }

        private void InstantiateWorkerThread()
        {
            workerThread = new BackgroundWorker();
            workerThread.ProgressChanged += WorkerThread_ProgressChanged;
            workerThread.DoWork += WorkerThread_DoWork;
            workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
            workerThread.WorkerReportsProgress = true;
            workerThread.WorkerSupportsCancellation = true;
        }

        private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStopWatch.Text = e.UserState.ToString();
        }

        private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                lblStopWatch.Text = "Cancelled";
            }
            else
            {
                lblStopWatch.Text = "Stopped";
            }            
        }

        private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startTime = DateTime.Now;

            _keepRunning = true;

            while (_keepRunning)
            {
                Thread.Sleep(1000);
               
                string timeElapsedInstring = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");

                workerThread.ReportProgress(0, timeElapsedInstring);     
               
                if(workerThread.CancellationPending)
                {
                    // this is important as it set the cancelled property of RunWorkerCompletedEventArgs to true
                    e.Cancel = true;
                    break;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            workerThread.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _keepRunning = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            workerThread.CancelAsync();          
        }
    }
}
