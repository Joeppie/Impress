using Impress.MinecraftText;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Components
{
    public partial class ColorPicker : FlowLayoutPanel
    {
        public ColorPicker()
        {
            this.SelectedColor = _renderHelper.ColorDictionary.Values.First();
            InitializeComponent();
        }

        public ColorPicker(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            PopulateColorLabels();
        }

        public Color SelectedColor { get; set; }
        public char SelectedChar { get; set; }
        private SelectableLabel SelectedLabel { get; set; }

        private MinecraftTextRenderHelper _renderHelper = new MinecraftTextRenderHelper();

        public void PopulateColorLabels()
        {

            foreach (KeyValuePair<char, Color> item in _renderHelper.ColorDictionary)
            {
                var label = new SelectableLabel
                    {
                        Text = item.Key.ToString(),
                        BackColor = item.Value,
                        Width = 15,
                        Height = 15,
                    };

                if (item.Key == '0')
                {
                    label.ForeColor = Color.White;
                }

                label.SelectedChanged += label_SelectedChanged;

                this.Controls.Add(label);
            }

        }

        void label_SelectedChanged(object Sender, EventArgs e)
        {
            var label = (Sender as SelectableLabel);
            if (label.Selected)
            {
                SelectedLabel = label;
                SelectedColor = label.SelectedColor;
                SelectedChar = _renderHelper.CharDictionary[SelectedColor];
            }
        }


        //Make this the selected colour of the colorpicker
        void label_Click(object sender, EventArgs e)
        {

            (sender as Label).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        }

    }
}
