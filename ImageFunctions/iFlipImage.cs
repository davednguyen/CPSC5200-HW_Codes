using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProcessorAPI.ImageFunctions
{
    public interface iFlipImage
    {
        string FlipImageHorizontal(string imageFile);
        string FlipImageVertical(string imageFile);
    }
}
