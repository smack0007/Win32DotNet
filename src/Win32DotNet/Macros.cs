using System;

namespace Win32DotNet
{
    public static class Macros
    {
        public static ushort LOWORD(IntPtr value)
        {
            return (ushort)(uint)value;
        }

        public static ushort HIWORD(IntPtr value)
        {
            return (ushort)((uint)value >> 16);
        }
    }
}
