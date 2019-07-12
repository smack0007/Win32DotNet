using System;
using System.Runtime.InteropServices;

namespace Win32DotNet
{
    public static class Kernel32
    {
        public const string DLL = "kernel32.dll";

        [DllImport(DLL, EntryPoint = "GetModuleHandle")]
        public static extern IntPtr GetModuleHandle(string module);
    }
}
