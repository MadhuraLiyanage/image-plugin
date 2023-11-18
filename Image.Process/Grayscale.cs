using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Process
{
    class Grayscale : IDisposable
    {
        internal Bitmap GrayscaleBitmap(Bitmap imageData)
        {
            int imageWidth = imageData.Width;
            int imageHeight = imageData.Height;
            int red;
            int green;
            int blue;
            int gray;
            for (int blurImageWidth = 0; blurImageWidth < imageWidth; blurImageWidth++)
            {
                for (int blurImageHeight = 0; blurImageHeight < imageHeight; blurImageHeight++)
                {
                    Color imageColor = imageData.GetPixel(blurImageWidth, blurImageHeight);
                    red = imageColor.R;
                    green = imageColor.G;
                    blue = imageColor.B;
                    gray = (byte)((.299 * red) +
                                 (.587 * green) +
                                 (.114 * blue));
                    red = gray;
                    green = gray;
                    blue = gray;

                    imageData.SetPixel(blurImageWidth, blurImageHeight, Color.FromArgb(red, green, blue));
                }
            }

            return imageData;
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
