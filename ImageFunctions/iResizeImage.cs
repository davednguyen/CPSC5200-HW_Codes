using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessorAPI.ImageFunctions
{
    public interface iResizeImage
    {
        string ResizeAnImage(string imageFile, int width, int height);
    }
}
