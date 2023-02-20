using System;

namespace CnBlogs.Youzai.ScreenKeyboard {
    internal static class KeyboardConstaint {
        internal static readonly short VK_F1 = 0x70;
        internal static readonly short VK_F2 = 0x71;
        internal static readonly short VK_F3 = 0x72;
        internal static readonly short VK_F4 = 0x73;
        internal static readonly short VK_F5 = 0x74;
        internal static readonly short VK_F6 = 0x75;
        internal static readonly short VK_F7 = 0x76;
        internal static readonly short VK_F8 = 0x77;
        internal static readonly short VK_F9 = 0x78;
        internal static readonly short VK_F10 = 0x79;
        internal static readonly short VK_F11 = 0x7A;
        internal static readonly short VK_F12 = 0x7B;

        internal static readonly short VK_LEFT = 0x25;
        internal static readonly short VK_UP = 0x26;
        internal static readonly short VK_RIGHT = 0x27;
        internal static readonly short VK_DOWN = 0x28;

        internal static readonly short VK_NONE = 0x00;
        internal static readonly short VK_ESCAPE = 0x1B;
        internal static readonly short VK_EXECUTE = 0x2B;
        internal static readonly short VK_CANCEL = 0x03;
        internal static readonly short VK_RETURN = 0x0D;
        internal static readonly short VK_ACCEPT = 0x1E;
        internal static readonly short VK_BACK = 0x08;
        internal static readonly short VK_TAB = 0x09;
        internal static readonly short VK_DELETE = 0x2E;
        internal static readonly short VK_CAPITAL = 0x14;
        internal static readonly short VK_NUMLOCK = 0x90;
        internal static readonly short VK_SPACE = 0x20;
        internal static readonly short VK_DECIMAL = 0x6E;
        internal static readonly short VK_SUBTRACT = 0x6D;

        internal static readonly short VK_ADD = 0x6B;
        internal static readonly short VK_DIVIDE = 0x6F;
        internal static readonly short VK_MULTIPLY = 0x6A;
        internal static readonly short VK_INSERT = 0x2D;

        internal static readonly short VK_OEM_1 = 0xBA;  // ';:' for US
        internal static readonly short VK_OEM_PLUS = 0xBB;  // '+' any country

        internal static readonly short VK_OEM_MINUS = 0xBD;  // '-' any country

        internal static readonly short VK_OEM_2 = 0xBF;  // '/?' for US
        internal static readonly short VK_OEM_3 = 0xC0;  // '`~' for US
        internal static readonly short VK_OEM_4 = 0xDB;  //  '[{' for US
        internal static readonly short VK_OEM_5 = 0xDC;  //  '\|' for US
        internal static readonly short VK_OEM_6 = 0xDD;  //  ']}' for US
        internal static readonly short VK_OEM_7 = 0xDE;  //  ''"' for US
        internal static readonly short VK_OEM_PERIOD = 0xBE;  // '.>' any country
        internal static readonly short VK_OEM_COMMA = 0xBC;  // ',<' any country
        internal static readonly short VK_SHIFT = 0x10;
        internal static readonly short VK_CONTROL = 0x11;
        internal static readonly short VK_MENU = 0x12;
        internal static readonly short VK_LWIN = 0x5B;
        internal static readonly short VK_RWIN = 0x5C;
        internal static readonly short VK_APPS = 0x5D;

        internal static readonly short VK_LSHIFT = 0xA0;
        internal static readonly short VK_RSHIFT = 0xA1;
        internal static readonly short VK_LCONTROL = 0xA2;
        internal static readonly short VK_RCONTROL = 0xA3;
        internal static readonly short VK_LMENU = 0xA4;
        internal static readonly short VK_RMENU = 0xA5;

        internal static readonly short VK_SNAPSHOT = 0x2C;
        internal static readonly short VK_SCROLL = 0x91;
        internal static readonly short VK_PAUSE = 0x13;
        internal static readonly short VK_HOME = 0x24;

        internal static readonly short VK_NEXT = 0x22;
        internal static readonly short VK_PRIOR = 0x21;
        internal static readonly short VK_END = 0x23;

        internal static readonly short VK_NUMPAD0 = 0x60;
        internal static readonly short VK_NUMPAD1 = 0x61;
        internal static readonly short VK_NUMPAD2 = 0x62;
        internal static readonly short VK_NUMPAD3 = 0x63;
        internal static readonly short VK_NUMPAD4 = 0x64;
        internal static readonly short VK_NUMPAD5 = 0x65;
        internal static readonly short VK_NUMPAD5NOTHING = 0x0C;
        internal static readonly short VK_NUMPAD6 = 0x66;
        internal static readonly short VK_NUMPAD7 = 0x67;
        internal static readonly short VK_NUMPAD8 = 0x68;
        internal static readonly short VK_NUMPAD9 = 0x69;

        internal static readonly short KEYEVENTF_EXTENDEDKEY    = 0x0001;
        internal static readonly short KEYEVENTF_KEYUP          = 0x0002;

        internal static readonly int GWL_EXSTYLE    = -20;
        internal static readonly int WS_DISABLED    = 0X8000000;
        internal static readonly int WM_SETFOCUS    = 0X0007;
    }
}
