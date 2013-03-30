using Impress.MinecraftText;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Impress.UIElements.Components
{
    class MinecraftTextLabel : Label
    {

        public delegate void PageChangedHandler(object Sender, EventArgs e);

        /// <summary>
        /// Is fired when Page has changed or MaxPageNumbers has changed.
        /// </summary>
        public event PageChangedHandler PageChanged;

        public List<MinecraftCharacter> MinecraftCharacters { get; private set; }


        private MinecraftTextRenderHelper RenderHelper;


        private int _page = 0;

        private int _selectionStart;
        private int _selectionEnd;


        public String CurrentPageText
        {
            get
            {

                char[] chars = MinecraftCharacters
                                 .Where(c => c.Page == this.Page)
                                 .Select(c => c.Char).ToArray();

                return new String(chars);
            }
        }

        private int _maxPageNumber = 0;



        /// <summary>
        /// Returns the highest page number.
        /// </summary>
        public int MaxPageNumber
        {
            get
            {
                return _maxPageNumber;
            }
        }

        [System.ComponentModel.DefaultValue(typeof(int),"0")]
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
                this.Invalidate(); //redrawing is immediately required.

                if (this.PageChanged != null)
                {
                    PageChanged(this, new EventArgs());
                }

            }
        }


        /// <summary>
        /// Stores at what character index (in raw string counting formatting codes) new pages begin.
        /// </summary>
        Dictionary<int, int> PageDictionary = new Dictionary<int, int>();

        public MinecraftTextLabel()
        {
            this.MouseDown += MinecraftTextLabel_MouseDown;
            this.MouseUp += MinecraftTextLabel_MouseUp;
            this.MouseHover += MinecraftTextLabel_MouseHover;

            //This fires after the repaint.

        }

        void MinecraftTextLabel_MouseHover(object sender, EventArgs e)
        {
           
        }

        void MinecraftTextLabel_MouseUp(object sender, MouseEventArgs e)
        {
            //Find out which line the 'unclick' was on.
            //Iterate over the characters on the clicked line for the current page to find out which was 'unclicked'.

           //We now have an 'up' and a 'down' character, simply loop over al characters that are between and highlight them.
        }


        //Todo reverse engineer where the mouse was pressed and allow selection via mouseup.
        void MinecraftTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            //Find out which line the click was on.
            //Iterate over the characters on the clicked line for the current page to find out which was clicked.

            int line = (int) (e.Y / RenderHelper.LineHeight);


            var characters = MinecraftCharacters.Where(c => c.Page == this.Page && c.Line == line);

            //The chronologically last character on this page that has a starting X coordinate that lies before cursor.
            //i.e. the one that was clicked on.
            var match = characters.OrderBy(c => c.originalIndex).LastOrDefault(c => c.Coordinate.X <= e.X && c.Display);


            if (match != null)
            {
                MessageBox.Show(match.Char.ToString());
            }

        }


        /// <summary>
        /// Ensures that the list of minecraftcharacters is properly filled;
        /// This is useful when the label that contains the text is not actually visible on screen.
        /// </summary>
        public void CalculateTextUsingRenderHelper()
        {
            RenderHelper = RenderHelper ?? new MinecraftTextRenderHelper();
            RenderHelper.BackgroundColor = this.BackColor;
            this.MinecraftCharacters = 
                RenderHelper.RenderCharactersUsingText(this.Text, this.CreateGraphics(), this.Page, false);

            UpdatePageCount();
        }

        private void UpdatePageCount()
        {
            //Determine the maximum page number and send a 'Page Changed' when the number of pages was mutated.
            int newMaxPageNumber = (MinecraftCharacters.Count > 0) ? Math.Max(MinecraftCharacters.Max(c => c.Page), 0) : 0;

            if (newMaxPageNumber != _maxPageNumber)
            {
                _maxPageNumber = newMaxPageNumber;

                if (this.PageChanged != null)
                {
                    PageChanged(this, new EventArgs());
                }
            }
        }





        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                //The renderhelper will rernder onto the graphics and also return a list of characters.
                //It is this list of characters that end up being used to decide what to send to the clipboard for MineCraft.
                RenderHelper = RenderHelper ?? new MinecraftTextRenderHelper();
                RenderHelper.BackgroundColor = this.BackColor;

                //render everything. Todo: optimize if this turns out to be slow.
                this.MinecraftCharacters = RenderHelper.RenderCharactersUsingText(this.Text, e.Graphics, this.Page,false);

                UpdatePageCount();
            }
            catch(Exception ex)
            {
                Debugger.Break(); //I want to detect this when debugging: it is vitally important to the application.
            }

            


        }



    }
}
