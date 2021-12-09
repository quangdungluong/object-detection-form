using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Drawing;
using System.Windows.Forms;
using Yolov5Net.App;

namespace FormImage
{
    public partial class ProcessImage : Form
    {
        YoloImage yoloImage;
        Bitmap image;
        Bitmap original;
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
                original = new Bitmap(fileDialog.FileName);
                image = new Bitmap(original, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = image;

                toolStripStatusLabel1.Text = "Upload Successfully..";
            }
        }

        private void Predict_Click(object sender, EventArgs e)
        {
            if (original != null)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                var mat= BitmapConverter.ToMat(original);
                yoloImage.Predict(mat);
                image = yoloImage.img;
                image = new Bitmap(image, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = image;

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();

                foreach (var row in yoloImage.results)
                {
                    string[] list = row.Split(",");
                    dataGridView1.Rows.Add(list);
                }
                watch.Stop();
                toolStripStatusLabel1.Text = $"Done... Execution time: {watch.ElapsedMilliseconds} ms";
            }
        }

        private void ProcessImage_Load(object sender, EventArgs e)
        {
            Mat img = new Mat();
            yoloImage = new YoloImage(img);
            toolStripStatusLabel1.Text = "Done..";
        }
    }
}
