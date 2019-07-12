using System;
using System.Runtime.InteropServices;

namespace Win32DotNet
{
    public static class Gdi32
    {
        public const string DLL = "gdi32.dll";

        [DllImport(DLL, EntryPoint = "GetStockObject")]
        public static extern IntPtr GetStockObject(int fnObject);
    }
}
