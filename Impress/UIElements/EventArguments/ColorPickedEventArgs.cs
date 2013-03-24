using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Impress.UIElements.EventArguments
{
    public class ColorPickedEventArgs : EventArgs
    {

        public Color Color { get; private set; }
        public char ColorCode { get; private set; }

        public ColorPickedEventArgs(Color color,char colorCode)
        {
            Color = color;
            ColorCode = colorCode;
        }



    }
}
