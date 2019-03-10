using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImageProcessorAPI.Models;
using static System.Net.Mime.MediaTypeNames.Image;
using ImageProcessor.Imaging;
using ImageProcessor.Web;
using ImageProcessor.Imaging.Formats;
using System.IO;
using ImageProcessor;
using System.Drawing;
using Simplicode.Imaging;
using System.Drawing.Imaging;

namespace ImageProcessorAPI.ImageFunctions
{
    public class ResizeImage :iResizeImage
    {
        /// <summary>
        /// Function to resize image based on request 
        /// </summary>
        /// <param name="imageFile">image file in format of base 64 string</param>
        /// <returns>resized image file in format of base 64 string</returns>
        public string ResizeAnImage(string imageFile, int width, int height)
        {
            string resizedImageFile = null;
            byte[] imgBytes = Convert.FromBase64String(imageFile);
            MemoryStream stream = new MemoryStream(imgBytes);
            Image info = Image.FromStream(stream);
            Bitmap smallerImage = new Bitmap(width, height);
            smallerImage.SetResolution(info.Width, info.Height);
            MemoryStream smallerStream = new MemoryStream();
            smallerImage.Save(smallerStream, ImageFormat.Jpeg);
            byte[] smallerImageBytes = smallerStream.ToArray();
            resizedImageFile = Convert.ToBase64String(smallerImageBytes);
            return resizedImageFile;
        }
    }
}
