using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMultiDllWrapper
{
    public enum KeyboardKey : byte
    {
        CapitalLock = 0x39,
        A = 0x04,
        B = 0x05,
        C = 0x06,
        D = 0x07,
        E = 0x08,
        F = 0x09,
        G = 0x0A,
        H = 0x0B,
        I = 0x0C,
        J = 0x0D,
        K = 0x0E,
        L = 0x0F,
        M = 0x10,
        N = 0x11,
        O = 0x12,
        P = 0x13,
        Q = 0x14,
        R = 0x15,
        S = 0x16,
        T = 0x17,
        U = 0x18,
        V = 0x19,
        W = 0x1A,
        X = 0x1B,
        Y = 0x1C,
        Z = 0x1D,
     
       
        Number1 = 0x1e,
        Number2 = 0x1f,
        Number3 = 0x20,
        Number4 = 0x21,
        Number5 = 0x22,
        Number6 = 0x23,
        Number7 = 0x24,
        Number8 = 0x25,
        Number9 = 0x26,
        Number0 = 0x27,

        Enter   = 0x28,
        Escape  = 0x29,
        Delete  = 0x2A,
        Tab     = 0x2B,
        Spacebar= 0x2C,
        Subtract= 0x2D,   // should be "-", but not on the numberpad
        
        F1      = 0x3A;
        F2      = 0x3B;
        F3      = 0x3C;
        F4      = 0x3D;
        F5      = 0x3E;
        F6      = 0x3F;
        F7      = 0x40;
        F8      = 0x41;
        F9      = 0x42;
        F10     = 0x43;
        F11     = 0x44;
        F12     = 0x45;
        
        PrintScreen     = 0x46;
        ScrollLock      = 0x47;
        Pause           = 0x48;
        Insert          = 0x49;
        Home            = 0x4A;
        PageUp          = 0x4B;
        Delete          = 0x4C;
        End             = 0x4D;
        PageDown        = 0x4E;
        RightArrow      = 0x4F;  // is "Arrow" neededß 
        LeftArrow       = 0x50;
        DownArrow       = 0x51;
        UpArrow         = 0x52;
        NumLock         = 0x53; 
        Divide          = 0x54;
        Multiply        = 0x55;
        Subtract        = 0x56;
        Add             = 0x57;
        
        
    }

    public enum KeyboardModifier : byte
    {
        LControl = 1,
        LShift = 2,
        LAlt = 4,
        LWin = 8,
        RShift = 32,
        RAlt = 64,
        RWin = 128
    }

    public class KeyboardReport
    {
        private const byte KBD_KEY_CODES = 6;
        private HashSet<KeyboardModifier> modifiers;
        private HashSet<KeyboardKey> pressedKeys;

        public KeyboardReport()
        {
            modifiers = new HashSet<KeyboardModifier>();
            pressedKeys = new HashSet<KeyboardKey>();
        }

        public KeyboardReport(IEnumerable<KeyboardModifier> modifiers, IEnumerable<KeyboardKey> pressedKeys)
        {
        }

        public void keyDown(KeyboardModifier modifier)
        {
            modifiers.Add(modifier);
        }

        public void keyDown(KeyboardKey key)
        {
            pressedKeys.Add(key);
        }

        public void keyUp(KeyboardModifier modifier)
        {
            modifiers.Remove(modifier);
        }

        public void keyUp(KeyboardKey key)
        {
            pressedKeys.Remove(key);
        }

        public byte getRawShiftKeyFlags()
        {
            byte shiftKeys = 0;
            foreach(KeyboardModifier modifier in modifiers)
            {
                shiftKeys |= (byte)modifier;
            }
            return shiftKeys;
        }
        public byte[] getRawKeyCodes()
        {
            byte[] keyCodes = new byte[KBD_KEY_CODES];
            byte i = 0;
            foreach (KeyboardKey key in pressedKeys)
            {
                if(i<=6)
                {
                    keyCodes[i++] = (byte)key;
                }
            }
            return keyCodes;
        }
    }

}
