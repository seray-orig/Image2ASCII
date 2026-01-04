
namespace Image2ASCII.Core
{
    internal abstract class ConverterBase
    {
        protected readonly IPictureLoader _pictureLoader;
        protected readonly IASCIIPrinter _asciiPrinter;
        protected List<Pixel> _pixels = new();

        protected ConverterBase(IPictureLoader pictureLoader, IASCIIPrinter asciiPrinter)
        {
            _pictureLoader = pictureLoader;
            _asciiPrinter = asciiPrinter;
        }

        protected virtual bool LoadPicture(string path)
        {
            try { _pictureLoader.Load(path, _pixels); return true; }
            catch { _pixels.Clear(); return false; }
        }
    }
}
