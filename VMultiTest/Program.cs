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
                Console.WriteLine("Connect: "+vmulti.connect());
                
                JoystickButtonState joyButtonState = new JoystickButtonState();
                joyButtonState.A = true;

                JoystickReport joystickReport = new JoystickReport(joyButtonState,0,0);

                Console.WriteLine("Update Joystick: "+vmulti.updateJoystick(joystickReport));
                vmulti.disconnect();
                System.Threading.Thread.Sleep(100000000);
            }
        }
    }
}
