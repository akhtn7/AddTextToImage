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
    public partial class FontItemForm : Form
    {
        public FontItemForm()
        {
            InitializeComponent();
        }

        private void btnOpenFileDialogShow_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Browse TrueType Font Files";
            openFileDialog.Filter = "TrueType fonts (*.ttf)|*.ttf";

            // Show the dialog.
            DialogResult result = openFileDialog.ShowDialog(); 
            
            if (result == DialogResult.OK) 
            {
                txtFontPath.Text = openFileDialog.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
