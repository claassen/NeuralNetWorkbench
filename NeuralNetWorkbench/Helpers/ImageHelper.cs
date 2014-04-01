using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NeuralNetWorkbench.Helpers
{
    public static class ImageHelper
    {
        public static ImageSource ImageSourceFromByteArray(byte[] data, int width, int height)
        {
            var dpiX = 96d;
            var dpiY = 96d;
            var pixelFormat = PixelFormats.Gray8;
            var bytesPerPixel = (pixelFormat.BitsPerPixel + 7) / 8;
            var stride = bytesPerPixel * width;

            return BitmapSource.Create(width, height, dpiX, dpiY, pixelFormat, null, data, stride);
        }
    }
}
