using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessorAPI.ImageFunctions
{
    /// <summary>
    /// Class function to perfomce flipping image
    /// </summary>
    public class FlipImage : iFlipImage
    {
        /// <summary>
        /// funcation to flip image horitonatlly 
        /// </summary>
        /// <param name="imageFile">image in string base 64</param>
        /// <returns>image in string base 64</returns>
        public string FlipImageHorizontal(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap flippedImage = new Bitmap(info.Width, info.Height);
            flippedImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            MemoryStream smallerStream = new MemoryStream();
            flippedImage.Save(smallerStream, ImageFormat.Jpeg);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }

        /// <summary>
        /// funcation to flip image vertically  
        /// </summary>
        /// <param name="imageFile">image in string base 64</param>
        /// <returns>image in string base 64</returns>
        public string FlipImageVertical(string imageFile)
        {
            string rotatedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap flippedImage = new Bitmap(info.Width, info.Height);
            flippedImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            MemoryStream smallerStream = new MemoryStream();
            flippedImage.Save(smallerStream, ImageFormat.Jpeg);
            byte[] smallerImageBytes = smallerStream.ToArray();
            rotatedImageFile = Convert.ToBase64String(smallerImageBytes);
            return rotatedImageFile;
        }
    }
}
