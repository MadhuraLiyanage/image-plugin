using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image.Plugin
{
    public interface IPlugin
    {
        public byte[] imageData { get; set; }
        public ImageFormat imageFormat { get; set; }
        public int resizePixels { get; set; }
        public int blurPixel { get; set; }
        public bool convetGrayscale { get; set; }

    

        //Unimplemented method for resizing
        byte[] Resize();
        //Unimplementaed method for Blur
        byte[] Blur();
        //Unimplemented method for Grayscale
        byte[] Grayscale();
    }
}
