using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Process
{
    class ResizeImage : IDisposable
    {
        internal Bitmap ResizeBitmap(Bitmap imageData, int resizeWidth, int resizeHeight)
        {
            Bitmap resizeBitmap = new Bitmap(resizeWidth, resizeHeight);

            using (Graphics graphics = Graphics.FromImage(resizeBitmap))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imageData, 0, 0, resizeWidth, resizeHeight);
            }

            return resizeBitmap;
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
