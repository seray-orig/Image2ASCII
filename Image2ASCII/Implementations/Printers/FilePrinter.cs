using Image2ASCII.Core;
using System.Text;

namespace Image2ASCII.Implementations.Printers
{
    internal class FilePrinter : IASCIIPrinter
    {
        public void Print(List<Pixel> pixels)
        {
            var Art = new StringBuilder();
            foreach (var pixel in pixels)
            {
                int brightness = (int)(pixel.Red * 0.299 + pixel.Green * 0.587 + pixel.Blue * 0.114);
                char symbol = StandardASCIIPrinter._gradient[brightness * (StandardASCIIPrinter._gradient.Length - 1) / 255];

                Art.Append(symbol, 2);
                if (pixel.Line)
                    Art.Append("\n");
            }
            File.AppendAllText("Art.txt", Art.ToString() + "\n");
        }
    }
}
