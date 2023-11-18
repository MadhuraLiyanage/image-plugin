using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image.Process;
//using Image.Plugin;

namespace ImageTesting
{
    public partial class FormImage : Form
    {
        public FormImage()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.pictureBoxOrgImage.Image = System.Drawing.Image.FromFile(@"Images\Flower.jpg");
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            byte[] imageData;
            //Convert Bitmap to byte array
            using (ConvertToByteArray convertToByteArray = new ConvertToByteArray())
            {
                imageData = convertToByteArray.ConvertBitmapToByteArray(new Bitmap(System.Drawing.Image.FromFile(@"Images\Flower.jpg")), ImageFormat.Jpeg);
            }
   
            //resize Image
            byte[] resizeImageData;
            using (Image.Process.Process process = new Image.Process.Process(imageData, ImageFormat.Jpeg, 150))
            {
                resizeImageData = process.Resize();
            }

            //Convert byte array to bitmap
            Bitmap bitmap;
            using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
            {
                bitmap = convertToBitmap.ConvertByteArrayToBitmap(resizeImageData);
            }
            this.pictureBoxConImage.Image = bitmap;
        }

        private void buttonBlurImage_Click(object sender, EventArgs e)
        {
            byte[] imageData;
            //Convert Bitmap to byte array
            using (ConvertToByteArray convertToByteArray = new ConvertToByteArray())
            {
                imageData = convertToByteArray.ConvertBitmapToByteArray(new Bitmap(System.Drawing.Image.FromFile(@"Images\Flower.jpg")), ImageFormat.Jpeg);
            }

            //resize Image
            byte[] blurImageData;
            using (Image.Process.Process process = new Image.Process.Process(imageData, ImageFormat.Jpeg,0,2))
            {
                blurImageData = process.Blur();
            }

            //Convert byte array to bitmap
            Bitmap bitmap;
            using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
            {
                bitmap = convertToBitmap.ConvertByteArrayToBitmap(blurImageData);
            }
            this.pictureBoxConImage.Image = bitmap;
        }

        private void buttonGrayImage_Click(object sender, EventArgs e)
        {
            byte[] imageData;
            //Convert Bitmap to byte array
            using (ConvertToByteArray convertToByteArray = new ConvertToByteArray())
            {
                imageData = convertToByteArray.ConvertBitmapToByteArray(new Bitmap(System.Drawing.Image.FromFile(@"Images\Flower.jpg")), ImageFormat.Jpeg);
            }

            //resize Image
            byte[] grayImageData;
            using (Image.Process.Process process = new Image.Process.Process(imageData, ImageFormat.Jpeg, 0, 0, true))
            {
                grayImageData = process.Grayscale();
            }

            //Convert byte array to bitmap
            Bitmap bitmap;
            using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
            {
                bitmap = convertToBitmap.ConvertByteArrayToBitmap(grayImageData);
            }
            this.pictureBoxConImage.Image = bitmap;
        }
    }
}
