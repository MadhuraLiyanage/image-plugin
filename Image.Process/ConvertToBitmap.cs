using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Process
{
    public class ConvertToBitmap : IDisposable
    {
        public Bitmap ConvertByteArrayToBitmap(byte[] imageData)
        {
            Bitmap bitmap=null;
            using (var memoryStream = new MemoryStream(imageData))
            {
                bitmap = new Bitmap(memoryStream);
            }
            return bitmap;
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
