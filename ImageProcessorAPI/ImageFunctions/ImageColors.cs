using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;



namespace ImageProcessorAPI.ImageFunctions
{
    public class ImageColors : iImageColorcs
    {
        /// <summary>
        /// Function to convert image to gray scale 
        /// </summary>
        /// <param name="imageFile">image fine in string base 64</param>
        /// <returns>image file in string base 64</returns>
        public string UpdateImagetoGrayscale(string imageFile)
        { 
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap grayscaledImage = new Bitmap(info.Width, info.Height);
            grayscaledImage.MakeTransparent();
            MemoryStream smallerStream = new MemoryStream();
            grayscaledImage.Save(smallerStream, ImageFormat.Jpeg);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }
    }
}
