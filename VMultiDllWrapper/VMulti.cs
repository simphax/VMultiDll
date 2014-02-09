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
        public static extern bool vmulti_update_joystick(IntPtr vmulti, ushort buttons, byte hat, byte x, byte y, byte z, byte rz, byte throttle);

        [DllImport("VMultiDll.dll")]
        public static extern bool vmulti_update_multitouch(IntPtr vmulti, MultitouchPointerInfoRaw[] pTouch, byte actualCount, byte request_type, byte report_control_id);

        IntPtr vmulti;
        bool connected;

        public VMulti()
        {
            vmulti = vmulti_alloc();
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
            if (connected)
            {
                return vmulti_update_joystick(vmulti, report.getButtonsRaw(), report.getPOVRaw(), report.getJoystickXRaw(), report.getJoystickYRaw(), 0, 128, 0);
            }
            else
            {
                return false;
            }
        }

        public bool updateMultitouch(MultitouchReport report)
        {
            if (connected)
            {
                return vmulti_update_multitouch(vmulti, report.getTouchesRaw(), report.getTouchesCountRaw(), report.getRequestType(), report.getReportControlId());
            }
            else
            {
                return false;
            }
        }

    }
}
