using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Forms
{
    public partial class ExplanationForm : Form
    {
        public ExplanationForm()
        {
            InitializeComponent();

            Assembly assembly = Assembly.GetExecutingAssembly();

            //The stream will be disposed by the StreamReader.
            Stream stream = File.OpenRead("readme.rtf");
            using (StreamReader reader = new StreamReader(stream))
            {
                this.richTextBox1.Rtf = reader.ReadToEnd();
            }

        }
    }
}
