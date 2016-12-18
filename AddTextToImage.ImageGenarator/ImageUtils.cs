using AddTextToImage.Data.Context;
using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using AddTextToImage.ImageGenerator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddTextToImage.ImageGenarator
{
    public class ImageUtils
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


        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap GetResultImage(Model model)
        {
            string fontPath = @"E:\xWork\Apps\Work\AddTextToImage\AddTextToImage.WebUI\fonts\";

            IRepository<TextTemplate> _textTemplateRepository = new Repository<TextTemplate>(new DbContextFactory());
            IRepository<ClipartTemplate> _clipartTemplateRepository = new Repository<ClipartTemplate>(new DbContextFactory());

            if (model == null)
                return null; //ToDo

            ImageConverter ic = new ImageConverter();
            Image img = (Image)ic.ConvertFrom(model.Image);
            Bitmap bmpResult = new Bitmap(img);

            Graphics graphics = Graphics.FromImage(bmpResult);

            foreach (var modelItem in model.Items)
            {
                TemplateBase template = null;

                if (modelItem.ItemType == 0)
                {
                    template = _textTemplateRepository.GetAllWithInclude("Font").Where(p => p.Id == modelItem.TemplateId).FirstOrDefault();
                }
                else
                {
                    template = _clipartTemplateRepository.GetAllWithInclude("Font").Where(p => p.Id == modelItem.TemplateId).FirstOrDefault();
                }

                OutlineTextProcessor outlineTextProcessor = new OutlineTextProcessor(modelItem, template, fontPath);
                Bitmap image = outlineTextProcessor.GetImage();

                graphics.DrawImage((Image)image, new Point(modelItem.PositionLeft, modelItem.PositionTop));
            }

            graphics.Flush();
            graphics.Dispose();

            return bmpResult;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn); //ToDo
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] BitmapToByteArray(Bitmap bmp)
        {
            byte[] byteArray = new byte[0]; //????
            using (MemoryStream stream = new MemoryStream())
            {
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        public static Bitmap ByteArrayToBitmap(byte[] array)
        {
            Bitmap bmp;

            using (MemoryStream stream = new MemoryStream(array))
            {
                bmp = new Bitmap(stream);
            }

            return bmp;
        }
    }
}
