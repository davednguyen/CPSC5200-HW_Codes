using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageProcessorUI.Models;

namespace ImageProcessorUI.ProcessImage
{
    public interface iProcessImageFunctions
    {
        string SendJsonRequest(string apiUrl, ImageData imageInfo);
        ImageData ConvertJsonObjectToImageInfo(string jsonObject);
        string GenerateImageFileFromString(string imageFile, string fileExtension);
        string SendJsonRequestV2(string apiUrl, ImageDataV2 imageInfo);
        ImageDataV2 ConvertJsonObjectToImageInfoV2(string jsonObject);
    }

}
