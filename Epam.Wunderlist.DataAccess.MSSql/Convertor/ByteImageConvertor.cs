using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Epam.Wunderlist.DataAccess.MSSql.Convertor
{
    public static class AvatarMapper
    {
        public static Byte[] ImageToByteArray(this Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
            return null;
        }

        public static Image ByteArrayToImage(this Byte[] byteArrayIn)
        {
            if (byteArrayIn != null && byteArrayIn.Length != 0)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;
        }

    }
}
