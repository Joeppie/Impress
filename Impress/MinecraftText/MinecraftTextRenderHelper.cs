using Impress.MinecraftText;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace Impress.MinecraftText
{
    class MinecraftTextRenderHelper : IDisposable
    {
        volatile Font _minecraftFont;
        volatile PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        public float LineHeight { get; private set; }

        public Brush CurrentBrush
        {
            get;
            private set;
        }

        public Font CurrentFont
        {
            get;
            private set;
        }

        public Font DefaultFont
        {
            get { return _minecraftFont; }
        }

        public Dictionary<char, Color> ColorDictionary
        {
            get;
            private set;
        }

        /// <summary>
        /// The backgroundcolor used when removing text.
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// For reverse lookup purposes of the color.
        /// </summary>
        public Dictionary<Color, char> CharDictionary
        {
            get;
            private set;
        }

        public Dictionary<char, Brush> BrushDictionary
        {
            get;
            private set;
        }

        public Dictionary<char, Font> FontDictionary
        {
            get;
            private set;
        }     

        private Brush GetBrush(char c)
        {
            Brush value;

            BrushDictionary.TryGetValue(c, out value);

            return value;
        }

        private Font GetFont(char c)
        {
            Font value;

            FontDictionary.TryGetValue(c, out value);

            return value ?? _minecraftFont;
        }

        public MinecraftTextRenderHelper() : this(16) { }

        /// <summary>
        /// Initializes an instance of the MinecraftTextRenderHelper using the specified fontsize
        /// </summary>
        /// <param name="fontSize">The fontsize to use when rendering characters.</param>
        public MinecraftTextRenderHelper(int fontSize)
        {
            ColorDictionary = new Dictionary<char, Color>(16);
            CharDictionary = new Dictionary<Color, char>(16);
            BrushDictionary = new Dictionary<char, Brush>(16);
            FontDictionary = new Dictionary<char, Font>();

            //Populate Colors.
            ColorDictionary.Add('0',  (Color.Black));
            ColorDictionary.Add('1',  (Color.FromArgb(0, 0, 170)));
            ColorDictionary.Add('2',  (Color.FromArgb(0, 170, 0)));
            ColorDictionary.Add('3',  (Color.FromArgb(0, 170, 170)));
            ColorDictionary.Add('4',  (Color.FromArgb(170, 0, 0)));
            ColorDictionary.Add('5',  (Color.FromArgb(170, 0, 170)));
            ColorDictionary.Add('6',  (Color.FromArgb(170, 170, 170)));
            ColorDictionary.Add('8',  (Color.FromArgb(85, 85, 85)));
            ColorDictionary.Add('9',  (Color.FromArgb(85, 85, 255)));
            ColorDictionary.Add('a',  (Color.FromArgb(85, 255, 85)));
            ColorDictionary.Add('b',  (Color.FromArgb(85, 255, 255)));
            ColorDictionary.Add('c',  (Color.FromArgb(255, 85, 85)));
            ColorDictionary.Add('d',  (Color.FromArgb(255, 85, 255)));
            ColorDictionary.Add('e',  (Color.FromArgb(255, 255, 85)));
            ColorDictionary.Add('f',  (Color.FromArgb(255, 255, 255)));

            foreach (var item in ColorDictionary)
            {
                CharDictionary.Add(item.Value, item.Key);
            }


            //Populate Brushes based on colors.
            foreach (KeyValuePair<char,Color> item in ColorDictionary)
            {
                BrushDictionary.Add(item.Key, new SolidBrush(item.Value));
            }
       

            try //This will fail in the form designer, since the font won't be found.
            {
                FontFamily[] fontFamilies;

                privateFontCollection.AddFontFile("font/minecraft_font_by_pwnage_block-d37t6nb.ttf");

                // Get the array of FontFamily objects.
                fontFamilies = privateFontCollection.Families;

                _minecraftFont = new Font(fontFamilies.First(), 16);

                FontDictionary.Add('l', new Font(fontFamilies.First(), 16, FontStyle.Bold));
                FontDictionary.Add('m', new Font(fontFamilies.First(), 16, FontStyle.Strikeout));
                FontDictionary.Add('n', new Font(fontFamilies.First(), 16, FontStyle.Underline));
                FontDictionary.Add('o', new Font(fontFamilies.First(), 16, FontStyle.Italic));

            }
            catch
            {
                _minecraftFont = new Font(FontFamily.GenericSansSerif, 16);
            }

        }

        //It would be more efficient to have this kind of implementation, eventually.
        ///// <summary>
        ///// Renders the given page using the existing generated MinecraftCharacters
        ///// </summary>
        ///// <param name="graphics"></param>
        ///// <param name="page"></param>
        ///// <returns></returns>
        //public void RenderCharacters(
        //            List<MinecraftCharacter> minecraftCharacters, Graphics graphics, int page)
        //{

        //    foreach (var character in minecraftCharacters.Where(c => c.Page == page && c.Display).ToList())
        //    {
        //        graphics.DrawString(
        //            character.Char.ToString(),
        //            character.Font,
        //            character.Brush,
        //            character.Coordinate
        //            );
        //    }
        //}


        /// <summary>
        ///  Renders the minecraft characters into a list and draws the given page.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="graphics"></param>
        /// <param name="page">zero based page index.</param>
        /// <param name="avoidPaint">When true, does not actually paint the characters onton the graphics object</param>
        /// <returns></returns>
        public List<MinecraftCharacter> RenderCharactersUsingText(String text, Graphics graphics, int? page,bool avoidPaint)
        {
            List<MinecraftCharacter> chars = new List<MinecraftCharacter>(text.Length);

            //not an exact measure. probably too wide, but the character width unfortunately
            //varies due to rendering/font differences.
            const int width = 318;

            const string CodeChars = "0123456789abcdefklmnor";
            const string CodeStarters = "&§";
            const int linesPerPage = 13;


            Brush defaultBrush = GetBrush('0'); //default
            Font defaultFont = GetFont('.'); //default

            Brush brush = defaultBrush; //default
            Font font = defaultFont; //default

            //Used to pretend the font was not reset, because of a bug in minecraft:
            //It will only actually reset with the reset-char even across lines. but probably not across pages. (I hope!)
            Font pretendFont;


            SolidBrush eraserBrush = new SolidBrush(BackgroundColor);

            float maxWidth = width;
            float currentWidth = 0;
            int currentLine = 0;
            int assumedPadding = 6;
            char? lastUsedCode = null;
            int whitespaceIndex = 0;
            MinecraftCharacter whitespaceChar = null;
            int indexInPage = 0;



            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            if (graphics.TextRenderingHint != System.Drawing.Text.TextRenderingHint.SingleBitPerPixel)
            {
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            }

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                char? n = text.Length > i + 1 ? (text[i + 1]) : (char?)null;

                if (currentLine % linesPerPage == 0 && currentWidth == 0)
                {
                    indexInPage = 0;
                }
                if (indexInPage > 254)
                {

                    //Go to the first line of the next page.       
                    currentLine += (linesPerPage - currentLine % linesPerPage);
                    indexInPage = 0;
                    currentWidth = 0;
                }


                //Handle formatting codes.
                if (c == '\n')
                {

                    chars.Add(new MinecraftCharacter
                    {
                        Char = c,
                        Brush = brush,
                        Font = font,
                        Line = currentLine,
                        Page = currentLine / linesPerPage,
                        Coordinate = new PointF(),
                        Display = false,
                        originalIndex = i
                    });
                    indexInPage++;

                    currentLine++;

                    currentWidth = 0;
                    continue;
                }
                else if (CodeStarters.Contains(c.ToString()) && n != null && CodeChars.Contains(n.ToString()))
                {
                    c = '§'; //& is not recognized.
                    chars.Add(new MinecraftCharacter
                    {
                        Char = c,
                        Brush = brush,
                        Font = font,
                        Line = currentLine,
                        Page = currentLine / linesPerPage,
                        Coordinate = new PointF(),
                        Display = false,
                        originalIndex = i
                    });
                    indexInPage++;



                    lastUsedCode = n;
                    if (n.Value == 'r')
                    {
                        brush = GetBrush('0');
                        font = GetFont('.');
                        pretendFont = GetFont('.'); ;
                    }
                    else
                    {
                        pretendFont = font;
                        //Todo: rewrite with nested if to support non-color codes, klmnno
                        brush = GetBrush(n.Value) ?? brush;
                        font = GetFont(n.Value) ?? font;
                    }

                    chars.Add(new MinecraftCharacter
                    {
                        Char = n.Value,
                        Brush = brush,
                        Font = font,
                        Line = currentLine,
                        Page = currentLine / linesPerPage,
                        Coordinate = new PointF(),
                        Display = false,
                        originalIndex = i
                    });
                    indexInPage++;
                    indexInPage++; //Code is consumed, but count towards max char count.

                    //Code has been processed, consume the two current charaters and continue processing.
                    i++;
                    continue;
                }
                else //normally drawn character.
                {

                    SizeF size = graphics.MeasureString(c.ToString(), font, 25);

                    if (font == GetFont('l'))
                    {
                        size.Width += 2; //pretend this is wider.
                    }

                    if (!Char.IsWhiteSpace(c))
                    {
                        size.Width -= assumedPadding;
                    }
                    else
                    {
                        //Do not place whitepaces on the first character of a line. Instead, just forget them
                        if (currentWidth == 0)
                        {
                            continue;
                        }

                        whitespaceIndex = i;
                    }

                    if (currentWidth + size.Width > maxWidth) //advance line.
                    {
                        //Now the real trouble starts: minecraft wants to keep words intact!

                        //perform a breakup.
                        if (whitespaceChar != null && whitespaceChar.Line == currentLine && whitespaceIndex != 0 && i != whitespaceIndex)
                        {
                            //Remove the characters already drawn, add an enter,
                            //forget the characters and start redrawing!

                            if (page == null && currentLine / linesPerPage == 0 || page == currentLine / linesPerPage)
                            {
                                if (!avoidPaint)
                                {
                                    graphics.FillRectangle(eraserBrush,
                                    new Rectangle(
                                    (int)Math.Round(whitespaceChar.Coordinate.X),
                                    (int)Math.Round(whitespaceChar.Coordinate.Y),
                                    (int)Math.Round(maxWidth - whitespaceChar.Coordinate.X),
                                    (int)Math.Round(size.Height)));
                                }
                            }

                            chars = chars.Take(whitespaceIndex).ToList();

                            PointF previousCoordinate = chars.Last().Coordinate;

                            //Explicit enter to avoid differences in printed book and previewed.
                            chars.Add(new MinecraftCharacter
                            {
                                Char = '\n',
                                Brush = brush,
                                Font = font,
                                Line = currentLine,
                                Page = currentLine / linesPerPage,
                                Coordinate = new PointF(previousCoordinate.X + 8,previousCoordinate.Y), //must differ for clicking.
                                Display = true,
                                originalIndex = i
                            });

                            indexInPage -= (i - whitespaceIndex) - 1; //one less, register that enter.
                            i -= i - whitespaceIndex;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
                            currentLine++;
                            currentWidth = 0;
                            continue; //On to the 'next' (first char of this word) character.

                        }


                        currentLine++;

                        currentWidth = 0;
                        indexInPage++;
                        //do not 'Continue', we still need to print the character in question.
                    }




                    PointF coordinate = new PointF(currentWidth, (currentLine % linesPerPage) * size.Height);
                    
                    LineHeight = size.Height;

                    //Either first page when rendering first thing, or specified page if different.
                    if (page == null && currentLine / linesPerPage == 0 || page == currentLine / linesPerPage)
                    {
                        if (!avoidPaint)
                        {
                            graphics.DrawString(c.ToString(), font, brush, coordinate);
                        }
                    }

                    currentWidth += size.Width;


                    chars.Add(new MinecraftCharacter
                    {
                        Char = c,
                        Brush = brush,
                        Font = font,
                        Line = currentLine,
                        Page = currentLine / linesPerPage,
                        Coordinate = coordinate,
                        Display = true
                    });
                    indexInPage++;

                    if (whitespaceIndex == i)
                    {
                        whitespaceChar = chars.Last();
                    }

                }


            }

            return chars;
        }


        public void Dispose()
        {
            foreach (Font font in FontDictionary.Values)
            {
                font.Dispose();
            }

            foreach (Brush brush in BrushDictionary.Values)
            {
                brush.Dispose();
            }

            _minecraftFont.Dispose();
            _minecraftFont = null;

            privateFontCollection.Dispose();
        }
    }
}
