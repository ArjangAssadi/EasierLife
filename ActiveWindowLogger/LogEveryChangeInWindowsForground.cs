using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ActiveWindowLogger
{
    public partial class LogEveryChangeInWindowsForground : Form
    {
        // Delegate and imports from pinvoke.net:

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
           hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
           uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        // Constants from winuser.h
        const uint EVENT_SYSTEM_FOREGROUND = 3;
        const uint WINEVENT_OUTOFCONTEXT = 0;

        private WinEventDelegate procDelegate;
        private IntPtr hhook;

        public LogEveryChangeInWindowsForground()
        {
            InitializeComponent();

            // Need to ensure delegate is not collected while we're using it,
            // storing it in a class field is simplest way to do this.
            procDelegate = new WinEventDelegate(WinEventProc);


            // Listen for foreground changes across all processes/threads on current desktop...
            hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        private void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Log.Text += string.Format("Foreground changed to {0:x8} \r\n", hwnd.ToInt32());
            //Log.Text += string.Format("WinEventProc Called with hWinEventHook={0:x8}, eventType={1}, hwnd={2:x8}, idObject={3},idChild{4}, dwEventThread={5}, dwmsEventTime={6} \r\n",hWinEventHook.ToInt32(), eventType, hwnd.ToInt32(), idObject, idChild, dwEventThread, dwmsEventTime);
        }
        private void LogEveryChangeInWindowsForground_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWinEvent(hhook);
        }

    }
}
