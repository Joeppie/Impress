using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Impress.ExtensionMethods
{
  public static  class  ColorExtensions
    {

        public static Color Invert(this Color color)
        {
          
                return Color.FromArgb(color.A,255 - color.R, 255 - color.G, 255 - color.G);

        }


    }
}
