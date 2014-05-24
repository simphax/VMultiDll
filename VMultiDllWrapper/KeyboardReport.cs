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
     
       
        Number1 = 0x1e
        Number2 = 0x1f
        Number3 = 0x20
        Number4 = 0x21
        Number5 = 0x22
        Number6 = 0x23
        Number7 = 0x24
        Number8 = 0x25
        Number9 = 0x26
        Number0 = 0x27
   
        
        
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
