using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainOldThread
{
    public class DestroyThreadExample
    {
        public bool IsCancelled { get; set; }

        public Thread MyThread { get; set; }

        public void StartThread()
        {
            MyThread = new Thread(() =>
            {
                int numberOfSeconds = 0;
                while (numberOfSeconds < 8)
                {
                    if (IsCancelled == false)
                    {
                        break;
                    }

                    Thread.Sleep(1000);

                    numberOfSeconds++;
                }

                Console.WriteLine("I ran for {0} seconds", numberOfSeconds);
            });
        }

        public void Abort()
        {
            //Destroy thread
            MyThread.Abort();
        }

        public void GracefulAbort()
        {
            IsCancelled = true;
        }
    }
}
