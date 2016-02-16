using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Web;
//using System.Web.Hosting;
using TextDesignerCSLibrary;
using AddTextToImage.Domain.Entities;

namespace AddTextToImage.ImageGenerator
{
    public class OutlineTextProcessor
    {
        private TemplateBase template;

        private ModelItem modelItem;

        private FontFamily fontFamily;

        private float fStartX = 0.0f;

        private float fStartY = 0.0f;

        private float fDestWidth = 0.0f;

        private float fDestHeight = 0.0f;

        ///<summary>
        /// Creates a new instance of the OutlineTextProcessor class.
        ///</summary>
        public OutlineTextProcessor(ModelItem modelItemParam, TemplateBase templateParam, string fontPathParam)
        {
            modelItem = modelItemParam;
            template = templateParam;

            PrivateFontCollection fontcollection = new PrivateFontCollection();
            fontcollection.AddFontFile(fontPathParam + template.Font.FileName);
            fontFamily = fontcollection.Families[0];
        }

        public Bitmap GetImage()
        {
            Bitmap result;

            switch (template.EffectType)
            {
                case 1:
                    result = TextNoOutline();
                    break;

                case 2:
                    result = TextOutline();
                    break;

                case 3:
                    result = TextDblOutline();
                    break;

                case 4:
                    result = TextGlow();
                    break;

                case 5:
                    result = TextDblGlow();
                    break;

                case 6:
                    result = TextGradOutline();
                    break;

                default:
                    result = TextNoOutline();
                    break;
            }

            if (modelItem.Rotation != 0)
                result = RotateBitmap(result, (float)modelItem.Rotation);

            return result;
        }


        private Bitmap TextNoOutline()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextNoOutline(ColorTranslator.FromHtml(modelItem.FontColor));

            outlineText.EnableShadow(template.ShadowEnable);
            outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextNoOutline(gradientBrush);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        private Bitmap TextOutline()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextOutline(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);

            outlineText.EnableShadow(template.ShadowEnable);

            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                   ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextOutline(gradientBrush, Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        private Bitmap TextDblOutline()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextDblOutline(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor2), template.OutlineThickness1, template.OutlineThickness2);

            outlineText.EnableShadow(template.ShadowEnable);

            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextDblOutline(gradientBrush, Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor2), template.OutlineThickness1, template.OutlineThickness2);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        private Bitmap TextGlow()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextGlow(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);

            outlineText.EnableShadow(template.ShadowEnable);
            
            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            fDestHeight++;

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextGlow(gradientBrush, Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        private Bitmap TextDblGlow()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextDblGlow(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor2), template.OutlineThickness1, template.OutlineThickness2);

            outlineText.EnableShadow(template.ShadowEnable);

            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextDblGlow(gradientBrush, Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor1), template.OutlineThickness1, template.OutlineThickness1);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        private Bitmap TextGradOutline()
        {
            OutlineText outlineText = new OutlineText();
            outlineText.TextGradOutline(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor2), template.OutlineThickness1);

            outlineText.EnableShadow(template.ShadowEnable);

            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight));

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextGradOutline(gradientBrush, Color.FromArgb(template.OutlineColor1), Color.FromArgb(template.OutlineColor2), template.OutlineThickness1);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }

        //ToDo - Delete
        private Bitmap TextOutlineX()
        {
            PngOutlineText outlineText = new PngOutlineText();

            outlineText.TextOutline(ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);
            outlineText.EnableReflection(false);

            outlineText.EnableShadow(template.ShadowEnable);

            if (template.ShadowEnable)
                outlineText.Shadow(Color.FromArgb(template.ShadowColor), template.ShadowThickness, new Point(template.ShadowOffsetX, template.ShadowOffsetY));

            Graphics g = Graphics.FromImage(new Bitmap(1, 1));

            outlineText.MeasureString(g, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text,
                new Point(0, 0), new StringFormat(), ref fStartX, ref fStartY, ref fDestWidth, ref fDestHeight);

            fDestHeight++;

            Bitmap image = new Bitmap((int)(fStartX + fDestWidth), (int)(fStartY + fDestHeight), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            outlineText.SetPngImage(image);

            Graphics graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            LinearGradientBrush gradientBrush = new LinearGradientBrush(new RectangleF(fStartX, fStartY, fDestWidth - (fStartX - 10), fDestHeight - (fStartY - 10)),
                   ColorTranslator.FromHtml(modelItem.FontColor), Color.FromArgb(template.TextColor2), LinearGradientMode.Vertical);

            if (template.TextGradientEnable)
                outlineText.TextOutline(gradientBrush, Color.FromArgb(template.OutlineColor1), template.OutlineThickness1);

            outlineText.DrawString(graphics, fontFamily, FontStyle.Regular, modelItem.FontSize, modelItem.Text, new Point(0, 0), new StringFormat());

            gradientBrush.Dispose();
            graphics.Dispose();
            g.Dispose();

            return image;
        }



        // Return a bitmap rotated around its center.
        private Bitmap RotateBitmap(Bitmap bm, float angle)
        {
            // Make a Matrix to represent rotation by this angle.
            Matrix rotate_at_origin = new Matrix();
            rotate_at_origin.Rotate(angle);

            // Rotate the image's corners to see how big
            // it will be after rotation.
            PointF[] points =
            {
                new PointF(0, 0),
                new PointF(bm.Width, 0),
                new PointF(bm.Width, bm.Height),
                new PointF(0, bm.Height),
            };
            rotate_at_origin.TransformPoints(points);
            float xmin, xmax, ymin, ymax;
            GetPointBounds(points, out xmin, out xmax, out ymin, out ymax);

            // Make a bitmap to hold the rotated result.
            int wid = (int)Math.Round(xmax - xmin);
            int hgt = (int)Math.Round(ymax - ymin);
            Bitmap result = new Bitmap(wid, hgt);

            // Create the real rotation transformation.
            Matrix rotate_at_center = new Matrix();
            rotate_at_center.RotateAt(angle,
                new PointF(wid / 2f, hgt / 2f));

            // Draw the image onto the new bitmap rotated.
            using (Graphics gr = Graphics.FromImage(result))
            {
                // Use smooth image interpolation.
                gr.InterpolationMode = InterpolationMode.High;

                // Clear with the color in the image's upper left corner.
                gr.Clear(bm.GetPixel(0, 0));

                //// For debugging. (Makes it easier to see the background.)
                //gr.Clear(Color.LightBlue);

                // Set up the transformation to rotate.
                gr.Transform = rotate_at_center;

                // Draw the image centered on the bitmap.
                int x = (wid - bm.Width) / 2;
                int y = (hgt - bm.Height) / 2;
                gr.DrawImage(bm, x, y);
            }

            // Return the result bitmap.
            return result;
        }

        // Find the bounding rectangle for an array of points.
        private void GetPointBounds(PointF[] points, out float xmin, out float xmax, out float ymin, out float ymax)
        {
            xmin = points[0].X;
            xmax = xmin;
            ymin = points[0].Y;
            ymax = ymin;
            foreach (PointF point in points)
            {
                if (xmin > point.X) xmin = point.X;
                if (xmax < point.X) xmax = point.X;
                if (ymin > point.Y) ymin = point.Y;
                if (ymax < point.Y) ymax = point.Y;
            }
        }


    }
}