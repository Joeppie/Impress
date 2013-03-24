using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Components
{
    public partial class FormattingControl : Panel
    {
        public char? FormatChar { get; private set; }
        public char ColorChar { get; private set; }

        private bool _exampleVisibile;
        private string _exampleTemplate;

        /// <summary>
        /// Gets or sets the Example text onto which the formatting is applied into {0}. 
        /// Example: ' &4"{0}a quoting example&4"&r ' would preview a certain quoting color.
        /// </summary>
        public string ExampleTemplate
        {
            get { return _exampleTemplate; }
            set
            {
                _exampleTemplate = value;
                UpdateLabel();
            }
        }

        /// <summary>
        /// Whether or not to clip off the example area.
        /// </summary>
        public bool ExampleVisible
        {
            get
            {
                return _exampleVisibile;
            }
            set
            {
                _exampleVisibile = value;
                if (_exampleVisibile)
                {
                    this.Height = 174;
                }

            }
        }



        public FormattingControl()
        {
            InitializeComponent();

            FormatChar = null;
            ColorChar = '0'; //default

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            colorPicker1.ColorPicked += colorPicker1_ColorPicked;
            formatPicker1.FormatPicked += formatPicker1_FormatPicked;

            ExampleTemplate = "Example"; //Default
        }

        void formatPicker1_FormatPicked(object sender, EventArguments.FormatPickedEventArgs e)
        {
            FormatChar = e.FormatCode == 'x' ? (char?)null : e.FormatCode;
            UpdateLabel();
        }

        void colorPicker1_ColorPicked(object sender, EventArguments.ColorPickedEventArgs e)
        {
            ColorChar = e.ColorCode;
            UpdateLabel();
        }

        public void UpdateLabel()
        {
            if (!FormatChar.HasValue)
            {
                Formatting = "&" + ColorChar;
                label2.Text = string.Format(ExampleTemplate, Formatting);
            }
            else
            {
                Formatting = "&" + ColorChar + "&" + FormatChar;
                label2.Text = string.Format(ExampleTemplate, Formatting);
            }


        }


        /// <summary>
        /// Returns the formatting picked by the user.
        /// </summary>
        public string Formatting
        {
            get;
            private set;
        }

    }
}
