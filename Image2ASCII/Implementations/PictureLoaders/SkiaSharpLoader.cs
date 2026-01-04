using Image2ASCII.Core;
using SkiaSharp;

namespace Image2ASCII.Implementations.PictureLoaders
{
    internal class SkiaSharpLoader : IPictureLoader
    {
        // Максимальная высота ASCII арта в символах
        private int _artHeight = 32;

        public void Load(string path, List<Pixel> pixels)
        {
            using SKBitmap Image = SKBitmap.Decode(path);

            if (Image == null)
                throw new ArgumentException("Неверный формат изображения или путь.");

            double scale = (double)Image.Height / _artHeight;

            for (int ArtY = 0; ArtY < _artHeight; ArtY++)
            {
                int ImgY = (int)(ArtY * scale);
                for (int ArtX = 0; ArtX < (int)(Image.Width / scale); ArtX++)
                {
                    int ImgX = (int)(ArtX * scale);

                    var color = Image.GetPixel(ImgX, ImgY);
                    pixels.Add(new Pixel
                    {
                        Line = false,
                        Red = color.Red,
                        Green = color.Green,
                        Blue = color.Blue
                    });
                }
                var pixel = pixels[^1];
                pixel.Line = true;
                pixels[^1] = pixel;
            }
        }
    }
}
