using AddTextToImage.Data.Context;
using AddTextToImage.Data.Service;
using AddTextToImage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddTextToImage.TemplateEditor.Forms
{
    public partial class FontListForm : Form
    {
        private readonly IRepository<FontInfo> _fontInfoRepository = new Repository<FontInfo>(new DbContextFactory());

        public FontListForm()
        {
            InitializeComponent();
        }

        private void FontListForm_Load(object sender, EventArgs e)
        {
            //this.dgvFonts.AutoGenerateColumns = false;

            this.dgvFonts.DataSource = _fontInfoRepository.GetAll().ToList<FontInfo>();
        }

        private void tsbtnFontAdd_Click(object sender, EventArgs e)
        {
            FontItemForm frm = new FontItemForm();

            frm.ShowDialog(this);
            frm.Dispose();
        }

    }
}
