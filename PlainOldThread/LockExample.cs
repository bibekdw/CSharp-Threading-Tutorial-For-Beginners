using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainOldThread
{
    

    public class LockExample
    {

        public int SharedResource { get; set; }

        public object _locker = 0;

        public void StartThreadAccessingSharedResource()
        {
            Thread t1 = new Thread(() =>
            {
                lock (_locker)
                {
                    SharedResource++;
                }

            });

            Thread t2 = new Thread(() =>
            {
                lock (_locker)
                {
                    SharedResource--;
                }

            });

            t1.Start();
            t2.Start();
        }
    }
}
