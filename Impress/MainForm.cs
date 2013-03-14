using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.Drawing.Text;
using System.Threading;
using Impress.ExtensionMethods;
using System.Text.RegularExpressions;
using System.IO;

namespace Impress
{
    public partial class MainForm : Form
    {

        volatile bool control = false;
        volatile bool printRequested = false;
        int keysdown = 0;


        public delegate void FileChangedHandler(object sender, EventArgs e);

        public event FileChangedHandler FileChanged;


        private KeyboardHookListener _listener;

        private bool _changed;
        public bool Changed
        {
            get
            {
                return _changed;
            }

            private set
            {
                if (FileChanged != null && _changed != value)
                {
                    _changed = value;
                    FileChanged(this, new EventArgs());
                    return;
                }
                _changed = value;
            }

        }



        BackgroundWorker worker = new BackgroundWorker();


        private void SetFormTitle()
        {
            this.Text = String.Format("Impress Book printer [{0}] {1}", OpenFileName ?? "new file", Changed ? "*" : "");
        }


        public MainForm()
        {
            InitializeComponent();

            SetFormTitle();
            SetPageXofYText();


            this.FileChanged += (s, e) => { SetFormTitle(); };
            this.FileChanged += (s, e) => { SetPageXofYText(); };

            label1.PageChanged += (s, e) => { SetPageXofYText(); };

            //Make user save if needed, or allow them to cancel the operation.
            this.FormClosing += (s, e) => { e.Cancel = !AskToSaveChangesIfNeeded(); };


            _listener = new KeyboardHookListener(new GlobalHooker());



            _listener.KeyDown += listener_KeyDown;
            _listener.KeyUp += listener_KeyUp;

            richTextBox1.Focus();


            //SendKeys.SendWait("{(}");


            _listener.Enabled = true;

            worker.DoWork += worker_DoWork;
        }

        private void SetPageXofYText()
        {
            label2.Text = String.Format("Page {0} of {1}.", label1.Page + 1, label1.MaxPageNumber + 1);
        }

        void label1_PageChanged(object Sender, EventArgs e)
        {
            SetPageXofYText();
        }


        //Todo: rewrite to detect ctrl-v and auto-populate first page, remove sendkeys dependency.
        void listener_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                keysdown--;
                control = false; //Not sure if this is the best way to detect.

                if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                {
                    control = false;
                    if (printRequested)
                    {

                        // Console.Beep();
                        if (!worker.IsBusy)
                        {
                            _listener.Enabled = false;
                            worker.RunWorkerAsync();
                        }
                        else
                        {
                            Console.Beep(300, 400);
                        }

                        printRequested = false;
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Prints the specified text using sendkeys in relatively small increments
        /// </summary>
        /// <param name="text">the textpage to print.</param>
        public void PrintPageInSteps(String text)
        {
            try
            {
                var blobs = text.SplitByLength(40)
                    //Replace enters by their sendkeys 'code'
                    //.Select(s => EscapeCharactersForSendkey(s))
                    .ToList();

                //  foreach (var blob in blobs)
                {
                    if (text.Last() == '\n')
                    {
                        text = new String(text.Take(text.Length - 1).ToArray());
                    }

                    Clipboard.SetText(text, TextDataFormat.Text);
                    //Thread.Sleep(400);
                    SendKeys.SendWait("^V");
                    //Thread.Sleep(200);
                }
            }
            catch
            {
                throw;
            }


        }



        void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            this.Invoke((MethodInvoker)delegate
            {

                PrintPageInSteps(label1.CurrentPageText);
                //SendKeys.Send(label1.CurrentPageText);
                Console.Beep(500, 20);
                if (label1.Page < label1.MaxPageNumber)
                {
                    label1.Page++;
                }
                else
                {
                    Thread.Sleep(100);
                    Console.Beep(800, 20);
                    Thread.Sleep(30);
                    Console.Beep(800, 20);
                }
                _listener.Enabled = true;
            });



        }

        void listener_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                keysdown++;

                if (e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey)
                {
                    control = true;
                }

                if ((e.KeyData == Keys.U) && control)
                {
                    e.Handled = true;
                    printRequested = true;
                }
            }
            catch
            {
                throw;
            }
        }

        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {
            label1.Text = richTextBox1.Text;
            Changed = true;
        }

        private void SetEnabledForPagesButtons()
        {
            //Todo but boring.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label1.Page > 0)
            {
                label1.Page--;
            }
            SetEnabledForPagesButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Page < label1.MaxPageNumber)
            {
                label1.Page++;
            }
            SetEnabledForPagesButtons();

        }


        const string fileFilter = "Text files (*.txt)|*.txt";

        public String OpenFileName { get; private set; }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            bool agreed = AskToSaveChangesIfNeeded();

            if (!agreed)
            {
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = fileFilter;
            dialog.ShowDialog();

            //Only if the user agreed, load the file.
            if (!String.IsNullOrEmpty(dialog.FileName))
            {
                using (FileStream stream = File.Open(dialog.FileName, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    richTextBox1.Text = reader.ReadToEnd();
                    OpenFileName = dialog.FileName;
                    this.Changed = false;
                }
            }

        }

        /// <summary>
        /// Returns false when there were changes and the user did not make a choice. (cancelled)
        /// </summary>
        /// <returns></returns>
        private bool AskToSaveChangesIfNeeded()
        {
            //Let user save unchanged changes first.
            if (Changed)
            {
                string fileName = OpenFileName ?? "your new file";
                string message = String.Format("Do you want so save changes to {0} first?", fileName);

                DialogResult result = MessageBox.Show(message, "Save Changes?", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    if (OpenFileName != null)
                    {
                        SaveFile();
                    }
                    else
                    {
                        SaveFileAs();
                    }
                }

                if (result == DialogResult.Cancel)
                {
                    return false; // abort and let the user do what they were doing.
                }

                return true; //user agreed.


            }
            return true; //No problems encountered.
        }

        private void SaveFileAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = fileFilter;
            dialog.ShowDialog();

            if (!String.IsNullOrEmpty(dialog.FileName))
            {
                OpenFileName = dialog.FileName;
                SaveFile();
            }
        }

        private void SaveFile()
        {
            using (FileStream stream = File.Create(OpenFileName))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(richTextBox1.Text);
                writer.Flush();
                Changed = false;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileName == null)
            {
                SaveFileAs();
            }
            else
            {
                SaveFile();
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "About Impress bookprinter";
            string text =
@"Impress was written by Joeppie (also my ingame MineCraft name) 

Joeppie@gmail.com";

            MessageBox.Show(text,title);
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ExplanationForm();
            form.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string capitalizationColor = "&4";
            string restorationColor = "&0";



            string replace =
                "${start}"
                + capitalizationColor
                + "${capital}"
                + restorationColor;

            string regex = @"(?<start>^\s*|(\.|\?|\!)\s*)(?<capital>[A-Z])";

            richTextBox1.Text = Regex.Replace(richTextBox1.Text, regex, replace);
        }

    }
}
