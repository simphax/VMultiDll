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
        
        [DllImport("VMultiDll.dll")]
        public static extern bool vmulti_connect(IntPtr vmulti, int i);

        [DllImport("VMultiDll.dll")]
        public static extern void vmulti_disconnect(IntPtr vmulti);

        [DllImport("VMultiDll.dll")]
        public static extern bool vmulti_update_joystick(IntPtr vmulti, ushort buttons, byte hat, byte x, byte y, byte rx, byte ry, byte throttle);

        IntPtr vmulti;
        bool connected;

        public VMulti()
        {
            vmulti = vmulti_alloc();
            Console.WriteLine("Success");
            Console.WriteLine(vmulti);
            vmulti_free(vmulti);
        }

        public bool connect()
        {
            return this.connected = vmulti_connect(vmulti, 1);
        }

        public void disconnect()
        {
            if (connected)
            {
                vmulti_disconnect(vmulti);
            }
        }

        public bool updateJoystick(JoystickReport report)
        {
            HelloWorld();

            if (connected)
            {

                ushort buttons = report.getButtonsRaw();

                return vmulti_update_joystick(vmulti, buttons, 0, report.getJoystickXRaw(), report.getJoystickYRaw(), 128, 128, 0);
            }
            else
            {
                return false;
            }
        }


    }
}
