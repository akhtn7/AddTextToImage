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
        private static Size getImageSize(string txt, FontFamily fontFamily, int fontSize)
        {
            Graphics graphics = Graphics.FromImage(new Bitmap(1, 1));
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            // Create the Font object for the image text drawing.
            Font font = new Font(fontFamily, fontSize, FontStyle.Regular);

            // Instantiating object of Bitmap image again with the correct size for the text and font.
            SizeF stringSize = graphics.MeasureString(txt, font, new PointF(0, 0), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));

            return Size.Round(stringSize);
        }

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

 
        /// <summary>
        /// Creates a new Image containing the same image only rotated
        /// </summary>
        /// <param name="image">The <see cref="System.Drawing.Image"/> to rotate</param>
        /// <param name="offset">The position to rotate from.</param>
        /// <param name="angle">The amount to rotate the image, clockwise, in degrees</param>
        /// <returns>A new <see cref="System.Drawing.Bitmap"/> of the same size rotated.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown if <see cref="image"/> is null.</exception>
        public static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }



       
    }
}