using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Forms.FormattingWizard
{
    public partial class FormattingForm : Form
    {
        public FormattingForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, IWin32Window window)
        {
            string oldTitle = Text;

            Text = title;
            DialogResult result = this.ShowDialog(window);

            Text = oldTitle;

            return result;
        }


        public DialogResult ShowDialog(string title)
        {
            string oldTitle = Text;

            Text = title;
            DialogResult result = this.ShowDialog();

            Text = oldTitle;

            return result;
        }

        /// <summary>
        /// Returns the formatting picked by the user.
        /// </summary>
        public string Formatting
        {
            get { return formattingControl1.Formatting; }
        }


        public string ExampleTemplate
        {
            get { return formattingControl1.ExampleTemplate; }
            set { formattingControl1.ExampleTemplate = value; }
        }



    }
}
