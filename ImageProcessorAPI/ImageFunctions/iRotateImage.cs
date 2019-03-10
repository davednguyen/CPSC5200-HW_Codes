using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessorAPI.ImageFunctions
{
    public interface iRotateImage
    {
        string RotateImageLeft(string imageFile);
        string RotateImageRight(string imageFile);
    }
}
