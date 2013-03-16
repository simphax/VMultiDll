using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VMultiDllWrapper
{
    public class VMulti
    {
        [DllImport("VMultiDll.dll")]
        public static extern void HelloWorld();

        [DllImport("VMultiDll.dll")]
        public static extern IntPtr vmulti_alloc();

        [DllImport("VMultiDll.dll")]
        public static extern void vmulti_free(IntPtr vmulti);
        /*
        __declspec(dllexport) BOOL vmulti_connect(pvmulti_client vmulti,int i);

__declspec(dllexport) void vmulti_disconnect(pvmulti_client vmulti);

        __declspec(dllexport) BOOL vmulti_update_joystick(pvmulti_client vmulti, USHORT buttons, BYTE hat, BYTE x, BYTE y, BYTE rx, BYTE ry, BYTE throttle);
         * */

        IntPtr vmulti;

        public VMulti()
        {
            vmulti = vmulti_alloc();
            Console.WriteLine("Success");
            Console.WriteLine(vmulti);
            vmulti_free(vmulti);
        }


        public void test()
        {
            HelloWorld();
        }


    }
}
