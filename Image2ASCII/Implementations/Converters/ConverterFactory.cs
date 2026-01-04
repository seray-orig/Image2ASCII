using Image2ASCII.Core;
using Image2ASCII.Implementations.PictureLoaders;
using Image2ASCII.Implementations.Printers;

namespace Image2ASCII.Implementations.Converters
{
    internal static class ConverterFactory
    {
        public static IConverter Create(string[] args)
        {
            if (args.Length > 0)
                return new ConveyorConverter(
                    new SkiaSharpLoader(),
                    new FilePrinter(),
                    args
                    );

            Console.WriteLine("1. Standard\n2. Pointer");
            switch (Console.ReadKey().Key.ToString())
            {
                case "D1":
                    return new StandardConverter(
                        new SkiaSharpLoader(),
                        new StandardASCIIPrinter()
                        );
                case "D2":
                    return new StandardConverter(
                        new SkiaSharpLoader(),
                        new PointerPrinter()
                        );
                default:
                    return new StandardConverter(
                        new SkiaSharpLoader(),
                        new StandardASCIIPrinter()
                        );
            }
        }
    }
}
