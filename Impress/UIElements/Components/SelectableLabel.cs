using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Impress.UIElements.Components
{
    class SelectableLabel : Label
    {

        public delegate void SelectedChangedHandler(object Sender, EventArgs e);
        public delegate void SelectedColorhangedHandler(object Sender, EventArgs e);


        /// <summary>
        /// Occurs when the label becomes selected or deselected.
        /// </summary>
        public event SelectedChangedHandler SelectedChanged;

        /// <summary>
        /// Occurs when the SelectedColor property is set.
        /// </summary>
        public event SelectedColorhangedHandler SelectedColorChanged;

        private Color _selectedColor;
        private bool _selected;

        /// <summary>
        /// The Color of the 'selection' indicator on the ribbon
        /// </summary>
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set
            {
                _selectedColor = value;
                if (SelectedColorChanged != null)
                {
                    SelectedColorChanged(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Whether or not this label has been selected.
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (SelectedChanged != null)
                {
                    SelectedChanged(this, new EventArgs());
                }
            }
        }

        public SelectableLabel()
        {
            this.SelectedChanged += (s, e) => { this.Invalidate(); };
            this.SelectedColorChanged += (s, e) => { this.Invalidate(); };

            this.Click += (s, e) => { this.Selected = !this.Selected; };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Paint on top of what base painted.
            if (Selected)
            {
                using(Brush brush = new SolidBrush(SelectedColor))
                using (Pen pen  = new Pen(brush,2))
                {
                    Rectangle rect = new Rectangle
                        (
                        2, 2, this.Width - 4, this.Height - 4
                        );


                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

    }
}
