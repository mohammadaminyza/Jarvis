using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Jarvis.VoiceAssistant.UWP.Comman
{
    public partial class ExtensionsColorUwp
    {
        public static byte HexToR(string hexColor)
        {
            byte r = byte.Parse(hexColor.Substring(3, 2), NumberStyles.HexNumber);

            return r;
        }

        public static byte HexToG(string hexColor)
        {
            byte g = byte.Parse(hexColor.Substring(5, 2), NumberStyles.HexNumber);
            return g;
        }

        public static byte HexToB(string hexColor)
        {
            byte b = byte.Parse(hexColor.Substring(7, 2), NumberStyles.HexNumber);
            return b;
        }

        public static byte HexToA(string hexColor)
        {
            byte a = byte.Parse(hexColor.Substring(1, 2), NumberStyles.HexNumber);
            return a;
        }
    }
}
