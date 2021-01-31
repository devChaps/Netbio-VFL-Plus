using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Netbio_VFL_Plus
{
    public static class Helper
    {


        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }




        public static string PadBold(byte b)
        {
            string bin = Convert.ToString(b, 2);
            return new string('0', 8 - bin.Length) + "<b>" + bin + "</b>";
        }


        public static string Pad(byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }


        public static string PadNibble(byte b)
        {
            return Int32.Parse(Convert.ToString(b, 2)).ToString("0000 0000");
        }
    }
}
