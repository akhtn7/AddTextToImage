using AddTextToImage.Domain.Entities;
using AddTextToImage.TemplateEditor.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class ModelPreviewFrom : Form
    {
        public Bitmap ModelPreviewImage { set; private get; }

        public ModelPreviewFrom()
        {
            InitializeComponent();
        }

        private void ModelPreviewFrom_Load(object sender, EventArgs e)
        {

        }

        private void pnlImage_Paint(object sender, PaintEventArgs e)
        {
            Bitmap img = Utils.ResizeImage(ModelPreviewImage, e.ClipRectangle.Width, e.ClipRectangle.Height);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            e.Graphics.DrawImage(img, new Point(0, 0));

            e.Graphics.Dispose();
        }
    }
}
