using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;


namespace Impress.MinecraftText
{
    /// <summary>
    /// Represent what is required to draw the character in a graphics object, together with other characters.
    /// Also contains information as to the colouring and formatting of the character, which can be used to regenerate
    /// the text with formatting.
    /// </summary>
    /// 
    [DebuggerDisplay("{Char} (line {Line} page {Page}")]
    class MinecraftCharacter
    {

        public MinecraftCharacter()
        {
            Display = true; //default value.
        }

        public Brush Brush { get;  set; }
        public Font Font { get;  set; }

        public char Char { get;  set; }

        /// <summary>
        /// Represents the original index, before additional enters and such were added.
        /// </summary>
        public int originalIndex { get; set; }
        
        public int Line { get;  set; }
        public int Page { get;  set; }
        public PointF Coordinate { get; set; }
        public SizeF Size{ get; set; }

        /// <summary>
        /// Whether the character should be actively rendered when displaying a book.
        /// </summary>
        public bool Display { get; set; }
    }
}
