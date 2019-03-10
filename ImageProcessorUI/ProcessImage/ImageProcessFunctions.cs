using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ImageProcessorUI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageProcessorUI.ProcessImage
{
    public class ImageProcessFunctions : iProcessImageFunctions
    {
        public ImageData ConvertJsonObjectToImageInfo(string jsonObject)
        {
            ImageData imageProcessResult;   
            imageProcessResult = JsonConvert.DeserializeObject<ImageData>(jsonObject);
            return imageProcessResult;
        }

        public ImageDataV2 ConvertJsonObjectToImageInfoV2(string jsonObject)
        {
            ImageDataV2 imageProcessResult;
            imageProcessResult = JsonConvert.DeserializeObject<ImageDataV2>(jsonObject);
            return imageProcessResult;
        }

        public string GenerateImageFileFromString(string imageFile, string fileExtension)
        {
            DirectoryInfo[] dirs = new DirectoryInfo("C:\\Users\\dnguyen\\Desktop\\TestImage\\").GetDirectories();
            string fileName = "test." + fileExtension;
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                foreach(DirectoryInfo dir in dirs)
                {
                    sw.WriteLine(dir.Name);
                }
            }

            return fileName;
        }

        public string SendJsonRequest(string apiUrl, ImageData imageInfo)
        {
            string jsonResult = null;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string loginjson = JsonConvert.SerializeObject(imageInfo);

                streamWriter.Write(loginjson);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    jsonResult= result.ToString();
                }
            }

            return jsonResult;
        }

        public string SendJsonRequestV2(string apiUrl, ImageDataV2 imageInfo)
        {
            string jsonResult = null;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string loginjson = JsonConvert.SerializeObject(imageInfo);

                streamWriter.Write(loginjson);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    jsonResult = result.ToString();
                }
            }

            return jsonResult;
        }
    }
}
