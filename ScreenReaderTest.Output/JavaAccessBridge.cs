using System;
using System.Runtime.InteropServices;

namespace ScreenReaderTest.Output
{
    class JavaAccessBridge
    {
        public const string WINDOWS_ACCESS_BRIDGE = "WindowsAccessBridge-64.dll";

        private MouseClickedDelegate _mouseClickDelegate;

        public JavaAccessBridge()
        {
            _mouseClickDelegate = new MouseClickedDelegate(HandleMouseClick);
        }

        public void Initialize()
        {
            Windows_run();
            setMouseClickedFP(_mouseClickDelegate);
        }

        private void HandleMouseClick(System.Int64 vmID, IntPtr jevent, IntPtr ac)
        {
            System.Diagnostics.Debug.WriteLine("this should output when it works instead of throwing an AccessViolationException");
        }

        [DllImport(WINDOWS_ACCESS_BRIDGE, SetLastError = true, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void Windows_run();

        [DllImport(WINDOWS_ACCESS_BRIDGE, SetLastError = true, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void setMouseClickedFP([MarshalAs(UnmanagedType.FunctionPtr)]MouseClickedDelegate fp);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void MouseClickedDelegate(System.Int64 vmID, IntPtr jevent, IntPtr ac);
    }
}
