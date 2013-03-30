using Impress.MinecraftText;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Impress.UIElements.EventArguments;

namespace Impress.UIElements.Components
{
    public partial class FormatPicker : FlowLayoutPanel
    {
        private static int labelSize = 24;
        private static int padding = labelSize;


        public delegate void FormatPickedHandler(object sender, FormatPickedEventArgs e);

        public event FormatPickedHandler FormatPicked;

        public FormatPicker()
        {
            InitializeComponent();
            PopulateColorLabels();
        }

        public FormatPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            PopulateColorLabels();
        }

        
        public char SelectedChar { get; set; }


        private Label selectedLabel;


        private MinecraftTextRenderHelper _renderHelper = new MinecraftTextRenderHelper(4);

        private Padding getPadding(double padding)
        {
            int intPadding = (int)Math.Round(padding);
            return new Padding(intPadding, Math.Max(intPadding - 4, 0), intPadding, intPadding);
        }


        private void Highlight(Label label)
        {
            this.SuspendLayout();
            label.Margin = new Padding((int)(labelSize * 0));
            label.Width = label.Height = (int)(labelSize * 1.5);
            label.BackColor = SystemColors.Highlight;
            this.ResumeLayout();
        }

        private void UnHighlight(Label label, bool suspend)
        {
            if (suspend)
            {
                this.SuspendLayout();
            }
            label.Margin = getPadding(labelSize * 0.25);
            label.Width = label.Height = labelSize;
            label.BorderStyle = BorderStyle.None;
            label.BackColor = SystemColors.ControlLight;
            if (suspend)
            {
                this.ResumeLayout();
            }
        }

        private void Select(Label label)
        {
            if(label == selectedLabel)
            {
                return;
            }

            this.SuspendLayout();
            if (selectedLabel != null)
            {
                UnHighlight(selectedLabel, false);
            }
            label.Margin = getPadding(labelSize * 0);
            label.Width = label.Height = (int)(labelSize * 1.5);
            label.BorderStyle = BorderStyle.Fixed3D;

            selectedLabel = label;

            this.ResumeLayout();
        }


        public void PopulateColorLabels()
        {
            this.SuspendLayout();



            var defaultList = new List<KeyValuePair<char, Font>>();
            defaultList.Add(new KeyValuePair<char, Font>('x', _renderHelper.DefaultFont));


            foreach (KeyValuePair<char, Font> item in _renderHelper.FontDictionary.Union(defaultList))
            {
                var label = new Label
                    {
                        BackColor = SystemColors.ControlLight,
                        AutoSize = false,
                        Text = item.Key.ToString(),
                        Font = item.Value,
                        Width = labelSize,
                        Height = (int)(labelSize*0.2),
                        TextAlign = ContentAlignment.TopCenter,
                        UseCompatibleTextRendering = false
                    };

                UnHighlight(label, false);



                var copy = item; //prevent access to modified closure.
                
                int dummy;
                //The numeric codes would be hard to read with a black text in front.
                if (int.TryParse(item.Key.ToString(),out dummy))
                {
                    label.ForeColor = Color.White;
                }

                label.MouseEnter += (s, e) => { if (label != selectedLabel) Highlight(label); };
                label.MouseLeave += (s, e) => { if (label != selectedLabel) UnHighlight(label, true); };

                //Update selection when a label is clicked.
                label.Click += (s, e) =>
                {
                    SelectedChar = copy.Key;
                    Select(label);

                    if (FormatPicked != null)
                    {
                        FormatPicked(this, new FormatPickedEventArgs(SelectedChar));
                    }

                };

                this.Controls.Add(label);
            }
            this.ResumeLayout();
        }



    }
}
