using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMultiDllWrapper;

namespace VMultiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                VMulti vmulti = new VMulti();
                vmulti.test();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
