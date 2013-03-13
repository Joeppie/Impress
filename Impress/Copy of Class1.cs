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
    class MinecraftTextLabelCopy: Label
    {

        volatile Font _minecraftFont;
        volatile PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        Dictionary<char, Brush> ColorDictionary = new Dictionary<char, Brush>(16);
        Dictionary<char, Font> FontDictionary = new Dictionary<char, Font>();


        
        private int _page { get; set; }

        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                if (PageDictionary.ContainsKey(value))
                {
                    _page = value;
                }
            }
        }


       /// <summary>
       /// Stores at what character index (in raw string counting formatting codes) new pages begin.
       /// </summary>
        Dictionary<int, int> PageDictionary = new Dictionary<int, int>();

        public MinecraftTextLabelCopy()
        {

            try
            {
                //Populate Colors.
                ColorDictionary.Add('0', new SolidBrush(Color.Black));
                ColorDictionary.Add('1', new SolidBrush(Color.FromArgb(0, 0, 170)));
                ColorDictionary.Add('2', new SolidBrush(Color.FromArgb(0, 170, 0)));
                ColorDictionary.Add('3', new SolidBrush(Color.FromArgb(0, 170, 170)));
                ColorDictionary.Add('4', new SolidBrush(Color.FromArgb(170, 0, 0)));
                ColorDictionary.Add('5', new SolidBrush(Color.FromArgb(170, 0, 170)));
                ColorDictionary.Add('6', new SolidBrush(Color.FromArgb(255, 170, 0)));
                ColorDictionary.Add('7', new SolidBrush(Color.FromArgb(170, 170, 170)));
                ColorDictionary.Add('8', new SolidBrush(Color.FromArgb(85, 85, 85)));
                ColorDictionary.Add('9', new SolidBrush(Color.FromArgb(85, 85, 255)));
                ColorDictionary.Add('a', new SolidBrush(Color.FromArgb(85, 255, 85)));
                ColorDictionary.Add('b', new SolidBrush(Color.FromArgb(85, 255, 255)));
                ColorDictionary.Add('c', new SolidBrush(Color.FromArgb(255, 85, 85)));
                ColorDictionary.Add('d', new SolidBrush(Color.FromArgb(255, 85, 255)));
                ColorDictionary.Add('e', new SolidBrush(Color.FromArgb(255, 255, 85)));
                ColorDictionary.Add('f', new SolidBrush(Color.FromArgb(255, 255, 255)));


               // throw new Exception();
                FontFamily[] fontFamilies;
                
                privateFontCollection.AddFontFile("font/minecraft_font_by_pwnage_block-d37t6nb.ttf");

                // Get the array of FontFamily objects.
                fontFamilies = privateFontCollection.Families;

                _minecraftFont = new Font(fontFamilies.First(), 16);


                FontDictionary.Add('l',new Font(fontFamilies.First(), 16,FontStyle.Bold));
                FontDictionary.Add('m',new Font(fontFamilies.First(), 16,FontStyle.Strikeout));
                FontDictionary.Add('n',new Font(fontFamilies.First(), 16,FontStyle.Underline));
                FontDictionary.Add('o',new Font(fontFamilies.First(), 16,FontStyle.Italic));




            }
            catch
            {
                _minecraftFont = new Font(FontFamily.GenericSansSerif, 16);
                            }
        }

        private Brush GetBrush(char c)
        {
            Brush value;

            ColorDictionary.TryGetValue(c, out value);

            return value;
        }

        private Font GetFont(char c)
        {
            Font value;

            FontDictionary.TryGetValue(c, out value);

            return value ?? _minecraftFont;
        }


        protected override void OnPaint(PaintEventArgs e)
        {

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



            Brush defaultBrush = GetBrush('0'); //default
            Font defaultFont = GetFont('.'); //default

            Brush brush = defaultBrush; //default
            Font font = defaultFont; //default



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



                    //Draw.
                    e.Graphics.DrawRectangle(new Pen(GetBrush('f')),
                        new Rectangle(
                            (int)Math.Round(coordinate.X),
                            (int)Math.Round(coordinate.Y),
                            (int)Math.Round(size.Width),
                            (int)Math.Round(size.Height)));

                    e.Graphics.DrawString(c.ToString(), font, brush, coordinate);

                    currentWidth += size.Width;

                }

            }



        }



    }
}
