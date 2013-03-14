using Impress.MinecraftText;
using System;
using System.Collections.Generic;
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

        public event PageChangedHandler PageChanged;

        public List<MinecraftCharacter> MinecraftCharacters { get; private set; }


        private MinecraftTextRenderHelper RenderHelper;


        private int _page = 1;


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



        /// <summary>
        /// Returns the highest page number.
        /// </summary>
        public int MaxPageNumber
        {
            get
            {
                if (MinecraftCharacters != null)
                {
                    return Math.Max(MinecraftCharacters.Max(c => c.Page), 0);
                }
                return 0;
            }
        }


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
        }

        void MinecraftTextLabel_MouseUp(object sender, MouseEventArgs e)
        {

        }


        //Todo reverse engineer where the mouse was pressed and allow selection via mouseup.
        void MinecraftTextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            //var chars = MinecraftCharacters.Where(c => c.Page == this.Page);


            //foreach (var c in chars)
            //{
            //    if(e.X >= c.Coordinate.X && e.X <= c.si )


            //}


        }


        private String previousText { get; set; }


        protected override void OnPaint(PaintEventArgs e)
        {

            //The renderhelper will rernder onto the graphics and also return a list of characters.
            //It is this list of characters that end up being used to decide what to send to the clipboard for MineCraft.
            RenderHelper = RenderHelper ?? new MinecraftTextRenderHelper();

            //render everything.
            this.MinecraftCharacters = RenderHelper.RenderCharactersUsingText(this.Text, e.Graphics, this.Page);
            previousText = Text;

        }



    }
}
