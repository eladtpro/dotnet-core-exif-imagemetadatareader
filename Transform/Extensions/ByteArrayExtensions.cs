using System;
using System.Text;

namespace ImageMetadata.Transform.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string GetString(this Byte[] bytes)
        {
            int lastIndex = Array.FindLastIndex(bytes, b => b != 0);
            if (lastIndex < 0)
                return string.Empty;
            if (lastIndex + 2 < bytes.Length)
                Array.Resize(ref bytes, lastIndex + 2);

            //little - endian Unicode(UCS - 2)
            //1200  Unicode UCS-2 Little-Endian (BMP of ISO 10646)
            //1201  Unicode UCS-2 Big-Endian

            Encoding bytesUCS = Encoding.GetEncoding(1200);
            string str = bytesUCS.GetString(bytes);

            //Encoding utf8 = Encoding.UTF8;
            //byte[] utf8Bytes = utf8.GetBytes(UTF2UCS);
            //byte[] isoBytes = Encoding.Convert(utf8, bytesUCS, utf8Bytes);




            //string str = Encoding.UTF8.GetString(bytes);
            return str;
        }
    }
}
