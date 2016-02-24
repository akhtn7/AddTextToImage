using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using AddTextToImage.Domain.Entities;
using System.IO;

namespace AddTextToImage.WebUI
{
    public class Utils
    {

        public static Size getImageSize(byte[] image)
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