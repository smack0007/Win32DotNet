using System;
using System.Runtime.InteropServices;

namespace Win32DotNet
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hWnd;
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public POINT pt;
    }
}
