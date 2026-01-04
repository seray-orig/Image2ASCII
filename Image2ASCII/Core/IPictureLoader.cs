using Image2ASCII.Core;

namespace Image2ASCII.Core
{
    internal interface IPictureLoader
    {
        void Load(string path, List<Pixel> pixels);
    }
}
