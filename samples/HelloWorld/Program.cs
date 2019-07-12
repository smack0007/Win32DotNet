using System;
using System.Runtime.InteropServices;
using static Win32DotNet.Kernel32;
using static Win32DotNet.User32;

namespace HelloWorld
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IntPtr hInstance = GetModuleHandle(null);

            WNDCLASSEX wc = new WNDCLASSEX
            {
                cbSize = (uint)Marshal.SizeOf(typeof(WNDCLASSEX)),
                style = 0,
                lpfnWndProc = WindowProc,
                cbClsExtra = 0,
                cbWndExtra = 0,
                hInstance = hInstance,
                hIcon = LoadIcon(IntPtr.Zero, IDI_APPLICATION),
                hCursor = LoadCursor(IntPtr.Zero, IDC_ARROW),
                hbrBackground = (IntPtr)(COLOR_WINDOW + 1),
                lpszMenuName = null,
                lpszClassName = typeof(Program).FullName,
                hIconSm = LoadIcon(IntPtr.Zero, IDI_APPLICATION)
            };

            var windowClass = RegisterClassEx(ref wc);

            if (windowClass == 0)
                throw new InvalidOperationException($"RegisterClassEx failed.");

            var hWnd = CreateWindowEx(
                WS_EX_APPWINDOW | WS_EX_WINDOWEDGE,
                typeof(Program).FullName,
                "Hello World!",
                WS_MINIMIZEBOX | WS_SYSMENU | WS_OVERLAPPED | WS_CAPTION,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                800,
                600,
                IntPtr.Zero,
                IntPtr.Zero,
                hInstance,
                IntPtr.Zero);

            if (hWnd == IntPtr.Zero)
                throw new InvalidOperationException($"CreateWindowEx failed.");

            ShowWindow(hWnd, SW_SHOWNORMAL);

            while (GetMessage(out var message, IntPtr.Zero, 0, 0))
            {
                TranslateMessage(ref message);
                DispatchMessage(ref message);
            }
        }

        // This ensures the delegate will not be garbage collected as long as the program is running.
        public static WndProc WindowProc = _WindowProc;

        private static IntPtr _WindowProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            switch (msg)
            {
                case WM_CLOSE:
                    DestroyWindow(hWnd);
                    break;

                case WM_DESTROY:
                    PostQuitMessage(0);
                    break;

                default:
                    return DefWindowProc(hWnd, msg, wParam, lParam);
            }

            return IntPtr.Zero;
        }
    }
}
