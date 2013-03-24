using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Impress.UIElements.Forms
{
    public partial class PrintForm : Form
    {
        private PrintForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Initializes the PrintForm
        /// </summary>
        /// <param name="inputString">The text to be printed to minecraft</param>
        /// <param name="mainForm">The main form</param>
        public PrintForm(string inputText,MainForm mainForm)
            : this()
        {

            NavigableMinecraftTextLabel.Label.PageChanged +=  (s, e) =>  { SetCopyButtonText();  };

            NavigableMinecraftTextLabel.Label.Text = inputText;
            
            //Needed since the label does not initially show on screen.
            NavigableMinecraftTextLabel.Label.CalculateTextUsingRenderHelper();

            this.FormClosed += (s, e) => { mainForm.WindowState = FormWindowState.Normal; };

            SetSmallSize();
            SetCopyButtonText();
        }

        private void SetCopyButtonText()
        {
            CopyButton.Text = String.Format("Copy page {0} of {1}",
                     NavigableMinecraftTextLabel.Label.Page + 1,
                     NavigableMinecraftTextLabel.Label.MaxPageNumber + 1
                     );
        }

        private void MonitorPasteCheckBoxClicked(object sender, EventArgs e)
        {

        }

        private void SetLargeSize()
        {
            this.ClientSize = new System.Drawing.Size(563, 443);
        }

        private void SetSmallSize()
        {
            this.ClientSize = new System.Drawing.Size(209, 121);
        }

        private void OnTopCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = OnTopCheckBox.Checked;
        }

        private void ShowPreviewCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (ShowPreviewCheckBox.Checked)
            {
                SetLargeSize();
            }
            else
            {
                SetSmallSize();
            }

        }


        /// <summary>
        /// Copies the current page and advances to the next, if possible.
        /// </summary>
        /// <param name="beep"></param>
        public void CopyCurrentPageAndAdvance(bool beep)
        {
            string text = NavigableMinecraftTextLabel.Label.CurrentPageText;

            if (text.Last() == '\n')
            {
                text = new String(text.Take(text.Length - 1).ToArray());
            }

            Clipboard.SetText(text, TextDataFormat.Text);

            NavigableMinecraftTextLabel.Label.Page = Math.Min(
                NavigableMinecraftTextLabel.Label.Page+1,
                NavigableMinecraftTextLabel.Label.MaxPageNumber);
        }


        private void CopyButtonClicked(object sender, EventArgs e)
        {
            CopyCurrentPageAndAdvance(false);
        }


       /* private IntPtr LowLevelKeyboardHook(int nCode, WindowsMessages wParam, [In] KBDLLHOOKSTRUCT lParam)
        {
            bool callNext = true;

            bool isKeyDown = (wParam == WindowsMessages.KEYDOWN || wParam == WindowsMessages.SYSKEYDOWN);
            bool isKeyUp = (wParam == WindowsMessages.KEYUP || wParam == WindowsMessages.SYSKEYUP);

            if ((nCode >= 0) && (isKeyDown || isKeyUp))
            {
                // the virtual key codes and the winforms Keys have the same enumeration
                // so we can freely cast back and forth between them
                Keys key = (Keys)lParam.vkCode;

                // Do your other processing here...
            }

            // if any handler returned false, trap the message
            return (callNext) ? User32.CallNextHookEx(_mainHook, nCode, wParam, lParam) : _nullNext;
        }


        /// <summary>
        /// Registers the user's LowLevelKeyboardProc with the system in order to
        /// intercept any keyboard events before processed in the regular fashion.
        /// This can be used to log all keyboard events or ignore them.
        /// </summary>
        /// <param name="hook">Callback function to call whenever a keyboard event occurs.</param>
        /// <returns>The IntPtr assigned by the Windows's sytem that defines the callback.</returns>
        private IntPtr RegisterLowLevelHook(LowLevelKeyboardProc hook)
        {
            IntPtr handle = IntPtr.Zero;

            using (Process currentProcess = Process.GetCurrentProcess())
            using (ProcessModule currentModule = currentProcess.MainModule)
            {
                IntPtr module = Kernel32.GetModuleHandle(currentModule.ModuleName);
                handle = User32.SetWindowsHookEx(HookType.KEYBOARD_LL, hook, module, 0);
            }

            return handle;
        }

        /// <summary>
        /// Unregisters a previously registered callback from the low-level chain.
        /// </summary>
        /// <param name="hook">IntPtr previously assigned to the low-level chain.
        /// Users should have stored the value given by 
        /// <see cref="Drs.Interop.Win32.LowLevelKeyboard.RegisterLowLevelHook"/>,
        /// and use that value as the parameter into this function.</param>
        /// <returns>True if the hook was removed, false otherwise.</returns>
        private bool UnregisterLowLevelHook(IntPtr hook)
        {
            return User32.UnhookWindowsHookEx(hook);
        }
        */
    }
}
