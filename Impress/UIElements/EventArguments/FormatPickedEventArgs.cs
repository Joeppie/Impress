using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Impress.UIElements.EventArguments
{
    public class FormatPickedEventArgs : EventArgs
    {

        public char FormatCode { get; private set; }

        public FormatPickedEventArgs(char formatCode)
        {
            FormatCode = formatCode;
        }

    }
}
