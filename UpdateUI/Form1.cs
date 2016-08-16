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
    public partial class Form1 : Form
    {
        public delegate void UpdateLabel(string label);

        public bool IsCancelled { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateUI(string labelText)
        {
            lblStopWatch.Text = labelText;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;

            IsCancelled = false;

            Thread t = new Thread(() =>
            {
                while (IsCancelled==false)
                {
                    Thread.Sleep(1000);

                    string timeElapsedInstring = (DateTime.Now - startTime).ToString(@"hh\:mm\:ss");

                    lblStopWatch.Invoke(new UpdateLabel(UpdateUI), timeElapsedInstring);
                    
                }
            });

          
            t.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
        }
    }
}
