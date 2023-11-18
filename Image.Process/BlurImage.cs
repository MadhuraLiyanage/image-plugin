using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Process
{
    class BlurImage : IDisposable
    {
        internal unsafe Bitmap BlurBitmap(Bitmap image, Int32 blurSize)
        {
            int orgImageWidth = image.Width;
            int orgImageHeight = image.Height;

            Rectangle rectangle = new Rectangle(0, 0, orgImageWidth, orgImageHeight);
            Bitmap blurredImage = new Bitmap(orgImageWidth, orgImageHeight);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurredImage))
            {
                graphics.DrawImage(image, new Rectangle(0, 0, orgImageWidth, orgImageHeight),
                    new Rectangle(0, 0, orgImageWidth, orgImageHeight), GraphicsUnit.Pixel);
            }

            // Lock the bitmap's bits
            BitmapData blurredImageData = blurredImage.LockBits(new Rectangle(0, 0, orgImageWidth, orgImageHeight), ImageLockMode.ReadWrite, blurredImage.PixelFormat);

            // Get bits per pixel for current PixelFormat
            int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(blurredImage.PixelFormat);

            // Get pointer to first line
            byte* scan0 = (byte*)blurredImageData.Scan0.ToPointer();

            // look at every pixel in the blur rectangle
            for (int blurRectX = rectangle.X; blurRectX < rectangle.X + rectangle.Width; blurRectX++)
            {
                for (int blurRectY = rectangle.Y; 
                        (blurRectY < rectangle.Y + rectangle.Height); 
                        blurRectY++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int avgRGBX = blurRectX; 
                            (avgRGBX < blurRectX + blurSize && avgRGBX < image.Width); 
                            avgRGBX++)
                    {
                        for (int avgRGBY = blurRectY; 
                            (avgRGBY < blurRectY + blurSize && avgRGBY < image.Height); 
                            avgRGBY++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + avgRGBY * blurredImageData.Stride + avgRGBX * bitsPerPixel / 8;

                            avgB += data[0]; // Blue
                            avgG += data[1]; // Green
                            avgR += data[2]; // Red

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int newColorX = blurRectX; 
                            (newColorX < blurRectX + blurSize && newColorX < image.Width && newColorX < rectangle.Width);
                            newColorX++)
                    {
                        for (int newColorY = blurRectY; 
                            (newColorY < blurRectY + blurSize && newColorY < image.Height && newColorY < rectangle.Height); 
                            newColorY++)
                        {
                            // Get pointer to RGB
                            byte* data = scan0 + newColorY * blurredImageData.Stride + newColorX * bitsPerPixel / 8;

                            // Change values
                            data[0] = (byte)avgB;
                            data[1] = (byte)avgG;
                            data[2] = (byte)avgR;
                        }
                    }
                }
            }

            // Unlock the bits
            blurredImage.UnlockBits(blurredImageData);

            return blurredImage;
        }


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
