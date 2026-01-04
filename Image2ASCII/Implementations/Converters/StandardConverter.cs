using Image2ASCII.Core;

namespace Image2ASCII.Implementations.Converters
{
    internal class StandardConverter : ConverterBase, IConverter
    {
        private bool _success = false;

        public StandardConverter(IPictureLoader pictureLoader, IASCIIPrinter asciiPrinter)
            : base(pictureLoader, asciiPrinter) { }

        public void Run()
        {
            Init();

            while (!_success)
            {
                Console.Write("Вставьте путь к картинке: ");
                var path = Console.ReadLine()?.Replace("\"", "");
                if (string.IsNullOrEmpty(path))
                    continue;

                if (LoadPicture(path))
                    _success = true;
            }

            _asciiPrinter.Print(_pixels);
            Console.ReadKey();
        }

        private void Init()
        {
            Console.Clear();
            Console.Title = "Standard Converter";
        }
    }
}
