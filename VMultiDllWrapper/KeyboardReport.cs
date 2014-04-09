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
        A = 4,
        B = 5,
        C = 6,
        D = 7,
        H = 0x0b,
        E = 0x08,
        L = 0x0f,
        O = 0x12,
        Number1 = 0x1e
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
