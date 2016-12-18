using System.Drawing;
using System.IO;

namespace AddTextToImage.WebUI
{
    public class Utils
    {

        public static Size GetImageSize(byte[] image)
        {
            Bitmap bmp;

            using (var ms = new MemoryStream(image))
            {
                bmp = new Bitmap(ms);
            }

            Size result = new Size();

            result.Height = bmp.Height;
            result.Width = bmp.Width;

            return result;
        }
    }
}