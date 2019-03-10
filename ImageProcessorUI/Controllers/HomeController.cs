using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ImageProcessorUI.Models;
using System.IO;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using BitmapNet;
using CoreExtensions;
using ImageProcessorUI.ProcessImage;
using Microsoft.AspNetCore.Hosting.Server;

namespace ImageProcessorUI.Controllers
{
    public class HomeController : Controller
    {
        //string bmpImagePath = Path.GetFullPath("C:\\Users\\dnguyen\\Desktop\\CSP500HW\\hw3frontend\\ImageProcessorUI\\ImageProcessorUI\\Data\\Test.bmp");
        //string bmpImagePath = Path.GetFullPath("C:\\Users\\dnguyen\\Desktop\\CSP500HW\\hw3frontend\\ImageProcessorUI\\ImageProcessorUI\\wwwroot\\data\\test.bmp");
        string gftImagePath = Path.GetFullPath("Data/test.gif");
        string jpgImagePath = Path.GetFullPath("Data/test.jpg");
        string pngImagePath = Path.GetFullPath("Data/test.png");
        string endPointAPI = "https://imageprocessorapi.azurewebsites.net/api/image";
        string endPointAPIV2 = "https://imageprocessorapi.azurewebsites.net/api/image/imageprocess";
        string bmpImagePath = Path.GetFullPath("C:\\Users\\mr4eyesn\\Desktop\\ImageprocessingUI\\ImageProcessorUI\\ImageProcessorUI\\ImageProcessorUI\\wwwroot\\data\\test.bmp");
        ImageData newImage = new ImageData
        {
            Id = 13,
            Title = "Test Image",
            NeedResize = true,
            ImageWidth = 40,
            ImageHeight = 40,
            NeedFlipHorizontal = true,
            NeedFlipVertical = true,
            NeedRotateLeft = true,
            NeedRotateRight = true,
            NeedConvertGrayscale = true
        }; 

        public IActionResult IndexV2()
        {
            iProcessImageFunctions processImage = new ImageProcessFunctions();
            var file = System.IO.Path.GetFullPath(bmpImagePath);
            var fileName = System.IO.Path.GetFileName(bmpImagePath);

            using (System.Drawing.Image bmpImage = System.Drawing.Image.FromFile(file))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    ImageData wholeImage = new ImageData();
                    bmpImage.Save(m, bmpImage.RawFormat);
                    wholeImage.ImageSoucePath = "/data/"+ fileName;
                    wholeImage.LoadImage = bmpImage;
                    byte[] imageBytes = m.ToArray();
                    wholeImage.SourceImageFile = Convert.ToBase64String(imageBytes);
                    wholeImage.Id = 123;
                    wholeImage.Title = "test image";
                    wholeImage.ImageHeight = 50;
                    wholeImage.ImageWidth = 40;
                    wholeImage.NeedConvertGrayscale = true;
                    wholeImage.NeedFlipHorizontal = true;
                    wholeImage.NeedFlipVertical = true;
                    wholeImage.NeedResize = true;
                    wholeImage.NeedRotateLeft = true;
                    wholeImage.NeedRotateRight = true;
                    wholeImage.NeedConvertGrayscale = true;
                    var sendRequestResult =  processImage.SendJsonRequest(endPointAPI, wholeImage);
                    var resultInImageData = processImage.ConvertJsonObjectToImageInfo(sendRequestResult);
                    resultInImageData.ImageSoucePath = wholeImage.ImageSoucePath;
                    var resizeImageFile = processImage.GenerateImageFileFromString(resultInImageData.ResizedImageFile, "jpg");
                    return View(resultInImageData);
                }
            }       
        }

        public IActionResult Index()
        {
            iProcessImageFunctions processImage = new ImageProcessFunctions();
            var file = System.IO.Path.GetFullPath(bmpImagePath);
            var fileName = System.IO.Path.GetFileName(bmpImagePath);
            Dictionary<string, bool> requestsList = new Dictionary<string, bool>();
            requestsList.Add("rs", true);
            requestsList.Add("rl", true);
            requestsList.Add("rr", true);
            requestsList.Add("fh", true);
            requestsList.Add("fv", true);
            requestsList.Add("gs", true);

            using (System.Drawing.Image bmpImage = System.Drawing.Image.FromFile(file))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    ImageDataV2 wholeImage = new ImageDataV2();
                    bmpImage.Save(m, bmpImage.RawFormat);
                    wholeImage.ImageSoucePath = "/data/" + fileName;
                    wholeImage.LoadImage = bmpImage;
                    byte[] imageBytes = m.ToArray();
                    wholeImage.SourceImageFile = Convert.ToBase64String(imageBytes);
                    wholeImage.Id = 123;
                    wholeImage.Title = "test image";
                    wholeImage.Height = 50;
                    wholeImage.Width = 40;
                    wholeImage.Requests = requestsList;
                    var sendRequestResult = processImage.SendJsonRequestV2(endPointAPIV2, wholeImage);
                    var resultInImageData = processImage.ConvertJsonObjectToImageInfoV2(sendRequestResult);
                    resultInImageData.ImageSoucePath = wholeImage.ImageSoucePath;
                    var resizeImageFile = processImage.GenerateImageFileFromString(resultInImageData.Image, "jpg");
                    return View(resultInImageData);
                }
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
