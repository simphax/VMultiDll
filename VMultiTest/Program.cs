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

            VMulti vmulti = new VMulti();
            Console.WriteLine("Connect: " + vmulti.connect());
            double i = 0;
            bool running = true;
            while (running)
            {
                JoystickButtonState joyButtonState = new JoystickButtonState();
                joyButtonState.A = false;
                joyButtonState.X = false;
                joyButtonState.Left = false;

                double x = Math.Sin(i);
                double y = Math.Cos(i);

                Console.WriteLine("x: "+x+" y: "+y);

                JoystickReport joystickReport = new JoystickReport(joyButtonState,x,y);

                Console.WriteLine("Update Joystick: "+vmulti.updateJoystick(joystickReport));

                i += 0.1;
                
                System.Threading.Thread.Sleep(100);
            }
            vmulti.disconnect();
        }
    }
}
