using Image2ASCII.Core;
using System.Text;

namespace Image2ASCII.Implementations.Printers
{
    internal class PointerPrinter : IASCIIPrinter
    {
        public static string _gradient = "░▒▓█";//{ "⠂", "⠄", "⠐", "⠠", "⠆", "⠒", "⠢", "⠔", "⠤", "⠰", "⠖", "⠦", "⠲", "⠴", "⠶" };
        public void Print(List<Pixel> pixels)
        {
            var Art = new StringBuilder();
            foreach (var pixel in pixels)
            {
                int brightness = (int)(pixel.Red * 0.299 + pixel.Green * 0.587 + pixel.Blue * 0.114);
                char asciiPixel = _gradient[brightness * (_gradient.Length - 1) / 255];

                Art.Append(asciiPixel, 2);
                if (pixel.Line)
                    Art.Append("\n");
            }
            File.WriteAllText("Art.txt", Art.ToString());
        }
    }
}
