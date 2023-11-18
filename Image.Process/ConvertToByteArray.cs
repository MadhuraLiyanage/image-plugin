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
    public class ConvertToByteArray : IDisposable
    {
        public byte[] ConvertBitmapToByteArray(Bitmap bitmap, ImageFormat imageFormat)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, imageFormat);
                return memoryStream.ToArray();
            }
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
