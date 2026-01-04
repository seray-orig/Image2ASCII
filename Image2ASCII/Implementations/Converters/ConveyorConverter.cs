using Image2ASCII.Core;

namespace Image2ASCII.Implementations.Converters
{
    internal class ConveyorConverter : ConverterBase, IConverter
    {
        private string[] _args;
        public ConveyorConverter(IPictureLoader pictureLoader, IASCIIPrinter asciiPrinter, string[] args)
            : base(pictureLoader, asciiPrinter) { _args = args; }

        public void Run()
        {
            foreach (string path in _args)
            {
                LoadPicture(path);
                _asciiPrinter.Print(_pixels);
                _pixels.Clear();
            }
        }
    }
}
