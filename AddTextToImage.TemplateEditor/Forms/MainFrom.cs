using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddTextToImage.TemplateEditor.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void tsbtnTextGalleryShow_Click(object sender, EventArgs e)
        {
            TextGalleryFrom frm = new TextGalleryFrom();
            
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void tsbtnClipartGalleryShow_Click(object sender, EventArgs e)
        {
            TemplateClipartGalleryForm frm = new TemplateClipartGalleryForm();

            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void tsbtnModelToSampleShow_Click(object sender, EventArgs e)
        {
            ModelToSampleListForm frm = new ModelToSampleListForm();

            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void tsbtnFontsShow_Click(object sender, EventArgs e)
        {
            FontListForm frm = new FontListForm();

            frm.ShowDialog(this);
            frm.Dispose();
        }
    }
}
