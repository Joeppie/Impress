using Impress.MinecraftText;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Impress
{
    class MinecraftTextLabel: Label
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

               char[] chars =  MinecraftCharacters
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
                if(MinecraftCharacters != null)
                {
                    return Math.Max(MinecraftCharacters.Max(c => c.Page),0); 
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

            RenderHelper = RenderHelper ?? new MinecraftTextRenderHelper();

            //if (previousText == this.Text)
            //{
            //    //re-render specific, currently-viewed page.
            //    RenderHelper.RenderCharacters(this.MinecraftCharacters,e.Graphics, this.Page);
            //}
            //else
            {
              //render everything.
              this.MinecraftCharacters = RenderHelper.RenderCharactersUsingText(this.Text, e.Graphics,this.Page);
            }

            //foreach (var character in MinecraftCharacters.Where(c => c.Page == this.Page && c.Display).ToList())
            //{
            //    break;
            //    e.Graphics.DrawString(
            //        character.Char.ToString(),
            //        character.Font,
            //        character.Brush,
            //        character.Coordinate
            //        );
            //}

            previousText = Text;


            /*
           //base.OnPaint(e);

            const string CodeChars = "0123456789abcdefklmnor";
            const string CodeStarters = "&§";
            const int linesPerPage = 13;


            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            if (e.Graphics.TextRenderingHint !=  System.Drawing.Text.TextRenderingHint.SingleBitPerPixel)
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
               // Thread.Sleep(100); 
            }



            //Todo add offset from the page dictionary, if the page is not the first page.

            float maxWidth = this.Width;
            float currentWidth = 0;
            int currentLine = 0;
            int assumedPadding = 6;
            char? lastUsedCode = null;
           

            for (int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                char? n = Text.Length > i + 1 ? (Text[i + 1]) : (char?)null;

                //Handle formatting codes.
                if (c == '\n')
                {
                    currentLine++;

                    if (currentLine == linesPerPage) //Max number of lines on a single minecraft book is 13. zero based
                    {
                        PageDictionary[this.Page] = i;
                        break;
                    }

                    currentWidth = 0;
                    continue;
                }
                else if (CodeStarters.Contains(c.ToString()) && n != null && CodeChars.Contains(n.ToString()))
                {
                    lastUsedCode = n;
                    if (n.Value == 'r')
                    {
                        brush = GetBrush('0');
                        Font = GetFont('.');
                    }
                    else
                    {
                        //Todo: rewrite with nested if to support non-color codes, klmnno
                        brush = GetBrush(n.Value) ?? brush;
                        font = GetFont(n.Value) ?? font;
                    }

                    //Code has been processed, consume the two current charaters and continue processing.
                    i++;
                    continue;
                }
                else //normally drawn character.
                {

                    SizeF size = e.Graphics.MeasureString(c.ToString(), _minecraftFont, 25);

                    if (!Char.IsWhiteSpace(c))
                    {
                        size.Width -= assumedPadding;
                    }

                    if (currentWidth + size.Width > maxWidth) //advance line.
                    {
                        currentLine++;
                        if (currentLine == linesPerPage) //Max number of lines on a single minecraft book is 13. zero based
                        {
                            PageDictionary.Add(this.Page + 1, i);
                            break;
                        }

                        currentWidth = 0;
                        //do not 'Continue', we still need to print the character in question.
                    }

                    


                    PointF coordinate = new PointF(currentWidth, currentLine * size.Height);


                    using (Pen pen = new Pen(RenderHelper.CurrentBrush))
                    {
                        //Draw.
                        e.Graphics.DrawRectangle(pen,
                            new Rectangle(
                                (int)Math.Round(coordinate.X),
                                (int)Math.Round(coordinate.Y),
                                (int)Math.Round(size.Width),
                                (int)Math.Round(size.Height)));
                    }
                    e.Graphics.DrawString(c.ToString(), RenderHelper.CurrentFont, RenderHelper.CurrentBrush, coordinate);

                    currentWidth += size.Width;

                }


            }
             * */

        }



    }
}
