using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainOldThread
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleThreadExample st = new SimpleThreadExample();
            st.StartMultipleThread();

            Console.ReadLine();

        }
    }
}
