using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Threading;
using Impress.ExtensionMethods;
using System.Text.RegularExpressions;
using System.IO;
using Impress.UIElements.Forms.FormattingWizard;
using Impress.UIElements.Components;

namespace Impress.UIElements.Forms
{
    public partial class MainForm : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();

        

        public delegate void FileChangedHandler(object sender, EventArgs e);

        public event FileChangedHandler FileChanged;


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


        private void SetFormTitle()
        {
            this.Text = String.Format("Impress Book printer [{0}] {1}", OpenFileName ?? "new file", Changed ? "*" : "");
        }


        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);


            SetFormTitle();
            
            this.FileChanged += (s, e) => { SetFormTitle(); };

            //Make user save if needed, or allow them to cancel the operation.
            this.FormClosing += (s, e) => { e.Cancel = !AskToSaveChangesIfNeeded(); };

            SourceTextBox.Focus();
        }


        private void SourceTextBoxTextChanged(object sender, EventArgs e)
        {
            navigableMinecraftTextLabel1.Label.Text = SourceTextBox.Text;
            Changed = true;
        }




        const string fileFilter = "Text files (*.txt)|*.txt";

        public String OpenFileName { get; private set; }

        private void loadToolStripMenuItemClicked(object sender, EventArgs e)
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
                using (StreamReader reader = new StreamReader( File.Open(dialog.FileName, FileMode.Open)))
                {
                    SourceTextBox.Text = reader.ReadToEnd();
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
            using (StreamWriter writer = new StreamWriter(File.Create(OpenFileName)))
            {
                writer.Write(SourceTextBox.Text);
                writer.Flush();
                Changed = false;
            }
        }

        private void saveToolStripMenuItemClicked(object sender, EventArgs e)
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

        private void saveAsToolStripMenuItemClicked(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void aboutToolStripMenuItemClicked(object sender, EventArgs e)
        {
            string title = "About Impress bookprinter";
            string text =
@"Impress was written by Joeppie (also my ingame Minecraft name) 

Joeppie@gmail.com";

            MessageBox.Show(text,title);
        }

        private void howToUseToolStripMenuItemClicked(object sender, EventArgs e)
        {
            var form = new ExplanationForm();
            form.ShowDialog(this);
        }

        private void AutoFormatWizardButtonClicked(object sender, EventArgs e)
        {
            var wizard = new AutoFormatWizard(navigableMinecraftTextLabel1.Label.Text);
            wizard.ShowDialog();

            if (wizard.DialogResult == DialogResult.OK)
            {
                SourceTextBox.Text = wizard.FormattedText;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var PrintForm = new PrintForm(navigableMinecraftTextLabel1.Label.Text,this);

            this.WindowState = FormWindowState.Minimized;
            PrintForm.Show();
        }

    }
}
