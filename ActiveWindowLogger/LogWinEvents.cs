using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveWindowLogger
{
    public partial class LogWinEvents : Form
    {
        private TextBox Log;

        public LogWinEvents()
        {
            InitializeComponent();
            Log = new DataGridTextBox();
            Log.Multiline = true;
            Log.Dock = DockStyle.Fill;
            this.Controls.Add(Log);
            this.FormClosing += LogWinEvents_FormClosing;
            procDelegate = new WinEventDelegate(WinEventProc);


            // Listen for name change changes across all processes/threads on current desktop...
            hhook = SetWinEventHook(EVENT_OBJECT_NAMECHANGE, EVENT_OBJECT_NAMECHANGE, IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        private void LogWinEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWinEvent(hhook);
        }

        private IntPtr hhook;

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
            IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
           hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
           uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        const uint EVENT_OBJECT_NAMECHANGE = 0x800C;
        const uint WINEVENT_OUTOFCONTEXT = 0;

        // Need to ensure delegate is not collected while we're using it,
        // storing it in a class field is simplest way to do this.
        WinEventDelegate procDelegate;


        void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            // filter out non-HWND namechanges... (eg. items within a listbox)
            if (idObject != 0 || idChild != 0)
            {
                return;
            }
            Log.Text += String.Format("Text of hwnd changed {0:x8} \r\n", hwnd.ToInt32());
        }
    }


}
