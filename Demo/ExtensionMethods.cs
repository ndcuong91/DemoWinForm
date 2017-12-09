using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public static class ExtensionMethods
    {
        public static byte[,] ToByteArray(this Bitmap bmp)
        {
            int numberChannel = 3;
            byte[,] data = new byte[bmp.Width, bmp.Height];
            try
            {
                System.Drawing.Imaging.BitmapData bitmapData = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* imagePointer = (byte*)(void*)bitmapData.Scan0.ToPointer();
                    int stride = bitmapData.Stride;

                    for (int i = 0; i < bmp.Height; i++)
                    {
                        byte* rowPointer = &imagePointer[i * stride];
                        for (int j = 0; j < bmp.Width * numberChannel; j += numberChannel)
                        {
                            data[j / 3, i] = rowPointer[j];
                        }
                    }
                }

                bmp.UnlockBits(bitmapData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }
    }
}
