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
    public partial class ColorPicker : FlowLayoutPanel
    {
        private static int labelSize = 16;
        private static int padding = labelSize;


        public delegate void ColorPickedHandler(object sender, ColorPickedEventArgs e);

        public event ColorPickedHandler ColorPicked;

        public ColorPicker()
        {
            this.SelectedColor = _renderHelper.ColorDictionary.Values.First();
            InitializeComponent();
            PopulateColorLabels();
        }

        public ColorPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            PopulateColorLabels();
        }

        public Color SelectedColor { get; set; }
        public char SelectedChar { get; set; }


        private Label selectedLabel;


        private MinecraftTextRenderHelper _renderHelper = new MinecraftTextRenderHelper();


        private void Highlight(Label label)
        {
            this.SuspendLayout();
            label.Margin = new Padding((int)(labelSize * 0));
            label.Width = label.Height = (int)(labelSize * 1.5);
            this.ResumeLayout();
        }

        private void UnHighlight(Label label, bool suspend)
        {
            if (suspend)
            {
                this.SuspendLayout();
            }
            label.Margin = new Padding((int)(labelSize * 0.25));
            label.Width = label.Height = labelSize;
            label.BorderStyle = BorderStyle.None;
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
            label.Margin = new Padding((int)(labelSize * 0));
            label.Width = label.Height = (int)(labelSize * 1.5);
            label.BorderStyle = BorderStyle.Fixed3D;

            selectedLabel = label;

            this.ResumeLayout();
        }


        public void PopulateColorLabels()
        {
            this.SuspendLayout();

            foreach (KeyValuePair<char, Color> item in _renderHelper.ColorDictionary)
            {
                var label = new Label
                    {
                        Text = item.Key.ToString(),
                        BackColor = item.Value,
                        Width = labelSize,
                        Height = labelSize,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };

                UnHighlight(label, false);


                
                int dummy;
                //The numeric codes would be hard to read with a black text in front.
                if (int.TryParse(item.Key.ToString(),out dummy))
                {
                    label.ForeColor = Color.White;
                }

                label.MouseEnter += (s, e) => { if (label != selectedLabel) Highlight(label); };
                label.MouseLeave += (s, e) => { if (label != selectedLabel) UnHighlight(label, true); };

                var copy = item; //prevent access to modified closure.

                //Update selection when a label is clicked.
                label.Click += (s, e) =>
                {
                    SelectedChar = copy.Key;
                    SelectedColor = copy.Value;
                    Select(label);

                    if (ColorPicked != null)
                    {
                        ColorPicked(this,new ColorPickedEventArgs(SelectedColor,SelectedChar));
                    }

                };

                this.Controls.Add(label);
            }
            this.ResumeLayout();
        }



    }
}
