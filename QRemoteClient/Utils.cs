using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace QRemoteClient
{
    class Utils
    {

        public static byte[] ImageToByte(Image img)
        {
            byte[] byteArray = new byte[10000];
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byteArray = stream.ToArray();
            stream.Close();
            stream.Dispose();
            return byteArray;
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            try
            {
                //string str = Encoding.ASCII.GetString(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                ms.Close();
                ms.Dispose();
                return returnImage;
            }
            catch
            {
                ms.Close();
                ms.Dispose();
                Bitmap bmp = new Bitmap(1366, 768);
                return bmp;
            }
        }
    }
}
