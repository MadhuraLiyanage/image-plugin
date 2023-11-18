using Image.Plugin;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Process
{
    public class Process : IPlugin, IDisposable
    {
        public byte[] imageData { get; set; }
        public ImageFormat imageFormat { get; set; }
        public int resizePixels { get; set; }
        public int blurPixel { get; set; }
        public bool convetGrayscale { get; set; }


        //Default contructor
        public Process()
        {
            this.imageData = null;
            this.imageFormat = ImageFormat.Bmp;
            this.resizePixels = 0;
            this.blurPixel = 0;
            this.convetGrayscale = false;
        }

        //All arg consturctor
        public Process(byte[] imageData, ImageFormat imageFormat, int resizePixels = 0, int blurPixel = 0, bool convetGrayscale = false)
        {
            this.imageData = imageData;
            this.imageFormat = imageFormat;
            this.resizePixels = resizePixels;
            this.blurPixel = blurPixel;
            this.convetGrayscale = convetGrayscale;
        }

        #region "Resize Image"
        public byte[] Resize()
        {
            if (this.imageData==null || this.resizePixels <= 0)
            {
                throw new ArgumentNullException();
            }

            //convert byte[] to bitmap
            Bitmap bitmap = null;
            try { 
                using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
                {
                    bitmap = convertToBitmap.ConvertByteArrayToBitmap(imageData);
                } 
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting byte array to Bitmap. " + ex.Message.ToString());
            }

            //Resizing image
            Bitmap resizeBitmap;
            try
            {
                using (ResizeImage resizeImage = new ResizeImage())
                {
                    resizeBitmap = resizeImage.ResizeBitmap(bitmap, this.resizePixels, this.resizePixels);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error resizing Bitmap. " + ex.Message.ToString());
            }

            //converting to byte array
            byte[] newImage = null;
            try
            {
                using (ConvertToByteArray convertToByteArray= new ConvertToByteArray())
                {
                    newImage = convertToByteArray.ConvertBitmapToByteArray(resizeBitmap, this.imageFormat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Bitmap to byte array. " + ex.Message.ToString());
            }


            return newImage;
        }
        #endregion

        #region "Blur Image"
        public byte[] Blur()
        {
            if (this.imageData == null || this.blurPixel <= 0)
            {
                throw new ArgumentNullException();
            }

            //convert byte[] to bitmap
            Bitmap bitmap = null;
            try
            {
                using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
                {
                    bitmap = convertToBitmap.ConvertByteArrayToBitmap(imageData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting bity array to bitmap. " + ex.Message.ToString());
            }

            //Blur image
            Bitmap blurBitmap;
            try
            {
                using (BlurImage blurImage = new BlurImage())
                {
                    blurBitmap = blurImage.BlurBitmap(bitmap, this.blurPixel);
                    //blurBitmap = blurImage.BlurBitmap(bitmap, this.blurPixel); 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Bitmap to blur. " + ex.Message.ToString());
            }

            //converting to byte array
            byte[] newImage = null;
            try
            {
                using (ConvertToByteArray convertToByteArray = new ConvertToByteArray())
                {
                    newImage = convertToByteArray.ConvertBitmapToByteArray(blurBitmap, this.imageFormat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Bitmap to byte array. " + ex.Message.ToString());
            }

            return newImage;
        }
        #endregion

        #region"Grayscale"
        public byte[] Grayscale()
        {
            if (this.imageData == null || this.convetGrayscale == false)
            {
                throw new ArgumentNullException();
            }

            //convert byte[] to bitmap
            Bitmap bitmap = null;
            try
            {
                using (ConvertToBitmap convertToBitmap = new ConvertToBitmap())
                {
                    bitmap = convertToBitmap.ConvertByteArrayToBitmap(imageData);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting bity array to bitmap. " + ex.Message.ToString());
            }

            //Grayscale image
            Bitmap grayscaleBitmap;
            try
            {
                using (Grayscale grayscale = new Grayscale())
                {
                    grayscaleBitmap = grayscale.GrayscaleBitmap(bitmap);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Bitmap to grayscale. " + ex.Message.ToString());
            }

            //converting to byte array
            byte[] newImage = null;
            try
            {
                using (ConvertToByteArray convertToByteArray = new ConvertToByteArray())
                {
                    newImage = convertToByteArray.ConvertBitmapToByteArray(grayscaleBitmap, this.imageFormat);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting Bitmap to byte array. " + ex.Message.ToString());
            }

            return newImage;
        }
        #endregion

        #region "Disposing Class"
        public void Dispose(bool dispose)
        {
            GC.SuppressFinalize(this);
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
