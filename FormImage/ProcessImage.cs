using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormImage
{
    public partial class ProcessImage : Form
    {
        public ProcessImage()
        {
            InitializeComponent();
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(fileDialog.FileName);
            }
        }

        private void Predict_Click(object sender, EventArgs e)
        {

        }
    }
}
